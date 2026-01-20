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
    public class RolemasterDataProvider:IRolemasterDataProvider
    {

        private readonly MplusDbContext _mplusDbContext;
        public RolemasterDataProvider(MplusDbContext mplusDbContext)
        {
            _mplusDbContext = mplusDbContext;
        }
        public async Task<bool> CreateRoleAsync(RolemasterDto rolemasterDto)
        {
            var Rolemaster = new Rolemaster
            {
                Rolecode = rolemasterDto.Rolecode,
                Rolename = rolemasterDto.Rolename,
                Createdon = DateOnly.FromDateTime(DateTime.UtcNow),
                Createdby = rolemasterDto.Createdby,
                Modifyon = DateOnly.FromDateTime(DateTime.UtcNow),
                Modifyby = rolemasterDto.Modifyby,
                Isdeleted = false
            };
            _mplusDbContext.Rolemaster.Add(Rolemaster);
            var rowsAffected = await _mplusDbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
        public async Task<bool> UpdateRoleAsync(RolemasterDto rolemasterDto)
        {
            var role = await _mplusDbContext.Rolemaster
                .FirstOrDefaultAsync(x => x.Roleid == rolemasterDto.Roleid);

            if (role == null)
                return false;

            role.Rolecode = rolemasterDto.Rolecode;
            role.Rolename = rolemasterDto.Rolename;
            role.Modifyby = rolemasterDto.Modifyby;
            role.Modifyon = DateOnly.FromDateTime(DateTime.UtcNow);
            return await _mplusDbContext.SaveChangesAsync() > 0;
        }
        public async Task<RolemasterDto?> GetRoleByIdAsync(long RoleId)
        {
            return await _mplusDbContext.Rolemaster
                .Where(x => x.Roleid == RoleId)
                .Select(x => new RolemasterDto
                {
                    Roleid = x.Roleid,
                    Rolecode = x.Rolecode,
                    Rolename = x.Rolename,
                })
                .FirstOrDefaultAsync();
        }
        public async Task<List<RolemasterDto>> GetRolesAsync()
        {
            return await _mplusDbContext.Rolemaster.Where(m => m.Isdeleted == false)
                .Select(x => new RolemasterDto
                {
                    Roleid = x.Roleid,
                    Rolecode= x.Rolecode,
                    Rolename= x.Rolename,
                })
                .ToListAsync();
        }
        public async Task<bool> DeleteRoleAsync(long RoleId)
        {
            var role = await _mplusDbContext.Rolemaster
                .FirstOrDefaultAsync(x => x.Roleid == RoleId);

            if (role == null)
                return false;

            role.Isdeleted = true;
            role.Modifyon = DateOnly.FromDateTime(DateTime.UtcNow);
            return await _mplusDbContext.SaveChangesAsync() > 0;
        }
    }
}
