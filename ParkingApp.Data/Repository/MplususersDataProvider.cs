using Microsoft.EntityFrameworkCore;
using ParkingApp.Data.Context;
using ParkingApp.Data.Entities;
using ParkingApp.Data.IRepositories;
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ParkingApp.Data.Repository
{
    public class MplususersDataProvider:IMplususersDataProvider
    {
        private readonly MplusDbContext _mplusDbContext;
        public MplususersDataProvider(MplusDbContext mplusDbContext)
        {
            _mplusDbContext = mplusDbContext;
        }

        public async Task<bool> CreateUserAsync(MplususersDto mplususersDto)
        {
            var Mplususers = new Mplususers
            {
                UserName = mplususersDto.UserName,
                UserCode = mplususersDto.UserCode,
                PasswordHash = mplususersDto.PasswordHash,
                Role= mplususersDto.Role,
                LastLoginAt = mplususersDto.LastLoginAt,
                Createdon = DateOnly.FromDateTime(DateTime.UtcNow),
                Createdby = mplususersDto.Createdby,
                ModifyOn = DateOnly.FromDateTime(DateTime.UtcNow),
                ModifyBy = mplususersDto.ModifyBy,
                IsDeleted = false
            };
            _mplusDbContext.Mplususers.Add(Mplususers);
            var rowsAffected = await _mplusDbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
        public async Task<MplususersDto?> UserLoginAsync(UserLogin userLogin)
        {
            return await (
                  from u in _mplusDbContext.Mplususers
                  join r in _mplusDbContext.Rolemaster on u.Role equals r.Roleid
                  where u.UserName == userLogin.UserName && u.IsDeleted == false
                  select new MplususersDto
                  {
                      UserId = u.UserId,
                      UserName = u.UserName,
                      PasswordHash = u.PasswordHash,
                      Role = u.Role,
                      RoleName = r.Rolename
                  }
              ).FirstOrDefaultAsync();
        }
        public async Task<List<ParentMenuDto>> GetMenusByRoleAsync(int roleId)
        {
            var menus = await(
                from rm in _mplusDbContext.Rolemenumapping
                join m in _mplusDbContext.Menumaster on rm.Menuid equals m.Menumasterid
                where rm.Roleid == roleId
                      && rm.Isdeleted == false
                      && m.Isdeleted == false
                select m
            ).ToListAsync();

            return menus
                .Where(m => m.Parentid == 0)
                .OrderBy(m => m.Displayorder)
                .Select(pm => new ParentMenuDto
                {
                    MenuId = pm.Menumasterid,
                    MenuName = pm.Menuname,
                    Icon = pm.Icon,
                    Children = menus
                        .Where(cm => cm.Parentid == pm.Menumasterid)
                        .OrderBy(cm => cm.Displayorder)
                        .Select(cm => new ChildMenuDto
                        {
                            MenuId = cm.Menumasterid,
                            MenuName = cm.Menuname,
                            RoutePath = cm.Routepath,
                            Icon = cm.Icon
                        })
                        .ToList()
                })
                .ToList();
        }
        public async Task<List<ParentMenuDto>> GetMenusByRoleOrEmployeeAsync(int roleId,long userId)
        {
            var roleMenus = await (
                from rm in _mplusDbContext.Rolemenumapping
                join m in _mplusDbContext.Menumaster
                    on rm.Menuid equals m.Menumasterid
                where rm.Roleid == roleId
                      && rm.Isdeleted == false
                      && m.Isdeleted == false
                select new
                {
                    Menu = m,
                    Source = "ROLE"
                }
            ).ToListAsync();
            var employeeMenus = await (
                from em in _mplusDbContext.Employeemenuaccess
                join m in _mplusDbContext.Menumaster
                    on em.Menumasterid equals m.Menumasterid
                where em.Userid == userId
                      && em.Isdeleted == false
                      && m.Isdeleted == false
                select new
                {
                    Menu = m,
                    Source = "EMPLOYEE",
                    em.Canread,
                    em.Canwrite,
                    em.Candelete
                }
            ).ToListAsync();

            var finalMenus = roleMenus
                .Where(rm => !employeeMenus.Any(em => em.Menu.Menumasterid == rm.Menu.Menumasterid))
                .Select(rm => rm.Menu)
                .Union(employeeMenus.Select(em => em.Menu))
                .DistinctBy(m => m.Menumasterid)
                .ToList();
            var result = finalMenus
                .Where(m => m.Parentid == 0)
                .OrderBy(m => m.Displayorder)
                .Select(pm => new ParentMenuDto
                {
                    MenuId = pm.Menumasterid,
                    MenuName = pm.Menuname,
                    Icon = pm.Icon,

                    Children = finalMenus
                        .Where(cm => cm.Parentid == pm.Menumasterid)
                        .OrderBy(cm => cm.Displayorder)
                        .Select(cm => new ChildMenuDto
                        {
                            MenuId = cm.Menumasterid,
                            MenuName = cm.Menuname,
                            RoutePath = cm.Routepath,
                            Icon = cm.Icon
                        })
                        .ToList()
                })
                .ToList();

            return result;
        }

        public async Task<List<MplususersDto>> GetUsersAsync()
        {
            return await (
                from u in _mplusDbContext.Mplususers
                join r in _mplusDbContext.Rolemaster
                    on u.Role equals r.Roleid
                where u.IsDeleted == false
                select new MplususersDto
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    Role = u.Role,
                    RoleName = r.Rolename
                }
            ).ToListAsync();
        }
        public async Task<MplususersDto?> GetUserByIdAsync(long Id)
        {
            return await (
                  from u in _mplusDbContext.Mplususers
                  join r in _mplusDbContext.Rolemaster on u.Role equals r.Roleid
                  where u.UserId == Id && u.IsDeleted == false
                  select new MplususersDto
                  {
                      UserId = u.UserId,
                      UserName = u.UserName,
                      PasswordHash = u.PasswordHash,
                      Role = u.Role,
                      RoleName = r.Rolename
                  }
              ).FirstOrDefaultAsync();
        }
        public async Task<bool> DeleteUserAsync(long Id)
        {
            var user = await _mplusDbContext.Mplususers
                .FirstOrDefaultAsync(x => x.UserId == Id);

            if (user == null)
                return false;

            user.IsDeleted = true;
            user.ModifyOn = DateOnly.FromDateTime(DateTime.UtcNow);
            return await _mplusDbContext.SaveChangesAsync() > 0;
        }
    }
}
