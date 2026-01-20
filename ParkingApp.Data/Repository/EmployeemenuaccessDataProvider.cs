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

namespace ParkingApp.Data.Repository
{
    public class EmployeemenuaccessDataProvider:IEmployeemenuaccessDataProvider
    {
        private readonly MplusDbContext _mplusDbContext;
        public EmployeemenuaccessDataProvider(MplusDbContext mplusDbContext)
        {
            _mplusDbContext = mplusDbContext;
        }
        public async Task<bool> AssignMenusToEmployeeAsync(EmployeemenuaccessDto employeemenuaccessDto)
        {
            var Employeemenuaccess = new Employeemenuaccess
            {
                Userid = employeemenuaccessDto.Userid,
                Menumasterid = employeemenuaccessDto.Menumasterid,
                Canread = employeemenuaccessDto.Canread,
                Canwrite = employeemenuaccessDto.Canwrite,
                Candelete = employeemenuaccessDto.Candelete,
                Createdon = DateOnly.FromDateTime(DateTime.UtcNow),
                Createdby = employeemenuaccessDto.Createdby,
                Modifyon = DateOnly.FromDateTime(DateTime.UtcNow),
                Modifyby = employeemenuaccessDto.Modifyby,
                Isdeleted = false
            };
            _mplusDbContext.Employeemenuaccess.Add(Employeemenuaccess);
            var rowsAffected = await _mplusDbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
        public async Task<bool> updateAssignMenusAsync(EmployeemenuaccessDto employeemenuaccessDto)
        {
            var Employeemenuaccess = await _mplusDbContext.Employeemenuaccess
                .FirstOrDefaultAsync(x => x.Accessid == employeemenuaccessDto.Accessid);

            if (Employeemenuaccess == null)
                return false;

            Employeemenuaccess.Userid = employeemenuaccessDto.Userid;
            Employeemenuaccess.Menumasterid = employeemenuaccessDto.Menumasterid;
            Employeemenuaccess.Canread = employeemenuaccessDto.Canread;
            Employeemenuaccess.Canwrite = employeemenuaccessDto.Canwrite;
            Employeemenuaccess.Candelete = employeemenuaccessDto.Candelete;
            Employeemenuaccess.Modifyon = DateOnly.FromDateTime(DateTime.UtcNow);
            Employeemenuaccess.Modifyby = employeemenuaccessDto.Modifyby;
            return await _mplusDbContext.SaveChangesAsync() > 0;
        }
        public async Task<EmployeemenuaccessDto?> GetAssignMenusByIdAsync(long Accessid)
        {
            return await _mplusDbContext.Employeemenuaccess
                .Where(x => x.Accessid == Accessid)
                .Select(x => new EmployeemenuaccessDto
                {
                    Accessid=x.Accessid,
                    Userid = x.Userid,
                    Menumasterid = x.Menumasterid,
                    Canread = x.Canread,
                    Canwrite = x.Canwrite,
                    Candelete = x.Candelete,
                })
                .FirstOrDefaultAsync();
        }
        public async Task<List<EmployeemenuaccessDto>> AssignMenusAsync(int userId)
        {
            return await (
                from ema in _mplusDbContext.Employeemenuaccess
                join mm in _mplusDbContext.Menumaster
                    on ema.Menumasterid equals mm.Menumasterid
                where ema.Isdeleted==false && ema.Userid == userId
                select new EmployeemenuaccessDto
                {
                    Accessid = ema.Accessid,
                    Userid = ema.Userid,
                    Menumasterid = ema.Menumasterid,
                    Menuname = mm.Menuname,
                    Canread = ema.Canread,
                    Canwrite = ema.Canwrite,
                    Candelete = ema.Candelete
                }
            ).ToListAsync();
        }

        public async Task<bool> DeleteAssignMenu(long Accessid)
        {
            var Employeemenuaccess = await _mplusDbContext.Employeemenuaccess
                .FirstOrDefaultAsync(x => x.Accessid == Accessid);

            if (Employeemenuaccess == null)
                return false;

            Employeemenuaccess.Isdeleted = true;
            Employeemenuaccess.Modifyon = DateOnly.FromDateTime(DateTime.UtcNow);
            return await _mplusDbContext.SaveChangesAsync() > 0;
        }
    }
}
