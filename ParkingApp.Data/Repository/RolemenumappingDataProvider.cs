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
    public class RolemenumappingDataProvider:IRolemenumappingDataProvider
    {
        private readonly MplusDbContext _mplusDbContext;
        public RolemenumappingDataProvider(MplusDbContext mplusDbContext)
        {
            _mplusDbContext = mplusDbContext;
        }
        public async Task<bool> CreateAssignMenusAsync(RolemenumappingDto rolemenumappingDto)
        {
            var Rolemenumapping = new Rolemenumapping
            {
                Roleid = rolemenumappingDto.Roleid,
                Menuid = rolemenumappingDto.Menuid,
                Createdon = DateOnly.FromDateTime(DateTime.UtcNow),
                Createdby = rolemenumappingDto.Createdby,
                Modifyon = DateOnly.FromDateTime(DateTime.UtcNow),
                Modifyby = rolemenumappingDto.Modifyby,
                Isdeleted = false
            };
            _mplusDbContext.Rolemenumapping.Add(Rolemenumapping);
            var rowsAffected = await _mplusDbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
        public async Task<bool> DeleteAssignMenuAsync(long id)
        {
            var roleMenu = await _mplusDbContext.Rolemenumapping
                .FirstOrDefaultAsync(x => x.Rolemenuid == id);

            if (roleMenu == null)
                return false;

            _mplusDbContext.Rolemenumapping.Remove(roleMenu);

            return await _mplusDbContext.SaveChangesAsync() > 0;
        }

    }
}
