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
    public class MenumasterDataProvider:IMenumasterDataProvider
    {
        private readonly MplusDbContext _mplusDbContext;
        public MenumasterDataProvider(MplusDbContext mplusDbContext)
        {
            _mplusDbContext = mplusDbContext;
        }
        public async Task<bool> CreateMenuAsync(MenumasterDto menumasterDto)
        {
            var Menumaster = new Menumaster
            {
                Menuname = menumasterDto.Menuname,
                Menutype = menumasterDto.Menutype,
                Parentid= menumasterDto.Parentid,
                Routepath = menumasterDto.Routepath,
                Icon = menumasterDto.Icon,
                Displayorder = menumasterDto.Displayorder,
                Createdon = DateOnly.FromDateTime(DateTime.UtcNow),
                Createdby = menumasterDto.Createdby,
                Modifyon = DateOnly.FromDateTime(DateTime.UtcNow),
                Modifyby = menumasterDto.Modifyby,
                Isdeleted = false
            };
            _mplusDbContext.Menumaster.Add(Menumaster);
            var rowsAffected = await _mplusDbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
        public async Task<List<MenumasterDto>> GetMenusAsync()
        {
            return await _mplusDbContext.Menumaster.Where(m => m.Isdeleted == false)
                .Select(x => new MenumasterDto
                {
                    Menumasterid = x.Menumasterid,
                    Menuname=x.Menuname,
                    Menutype=x.Menutype,
                    Parentid = x.Parentid,
                    Displayorder=x.Displayorder,
                    Routepath=x.Routepath,
                    Icon = x.Icon,
                })
                .ToListAsync();
        }
        public async Task<bool> UpdateMenuAsync(MenumasterDto menumasterDto)
        {
            var menu = await _mplusDbContext.Menumaster
                .FirstOrDefaultAsync(x => x.Menumasterid == menumasterDto.Menumasterid);

            if (menu == null)
                return false;

            menu.Menuname = menumasterDto.Menuname;
            menu.Menutype = menumasterDto.Menutype;
            menu.Parentid = menumasterDto.Parentid;
            menu.Routepath = menumasterDto.Routepath;
            menu.Icon = menumasterDto.Icon;
            menu.Displayorder = menumasterDto.Displayorder;
            menu.Modifyon = DateOnly.FromDateTime(DateTime.UtcNow);
            menu.Modifyby = menumasterDto.Modifyby;
            return await _mplusDbContext.SaveChangesAsync() > 0;
        }
        public async Task<MenumasterDto?> GetMenuByIdAsync(long Id)
        {
            return await _mplusDbContext.Menumaster
                .Where(x => x.Menumasterid == Id)
                .Select(x => new MenumasterDto
                {
                    Menumasterid = x.Menumasterid,
                    Menuname = x.Menuname,
                    Menutype = x.Menutype,
                    Parentid = x.Parentid,
                    Routepath = x.Routepath,
                    Icon = x.Icon,
                    Displayorder = x.Displayorder,
                })
                .FirstOrDefaultAsync();
        }
        public async Task<bool> DeleteMenuAsync(long Id)
        {
            var menu = await _mplusDbContext.Menumaster
                .FirstOrDefaultAsync(x => x.Menumasterid == Id);

            if (menu == null)
                return false;

            menu.Isdeleted = true;
            menu.Modifyon = DateOnly.FromDateTime(DateTime.UtcNow);
            return await _mplusDbContext.SaveChangesAsync() > 0;
        }
    }
}
