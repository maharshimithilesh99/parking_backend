using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.IRepositories
{
    public interface IRolemasterDataProvider
    {
        Task<bool> CreateRoleAsync(RolemasterDto rolemasterDto);
        Task<bool> UpdateRoleAsync(RolemasterDto rolemasterDto);
        Task<RolemasterDto?> GetRoleByIdAsync(long RoleId);
        Task<List<RolemasterDto>> GetRolesAsync();
        Task<bool> DeleteRoleAsync(long RoleId);
    }
}
