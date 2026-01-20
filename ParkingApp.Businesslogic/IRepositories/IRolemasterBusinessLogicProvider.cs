using ParkingApp.Businesslogic.Helpers;
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Businesslogic.IRepositories
{
    public interface IRolemasterBusinessLogicProvider
    {
        Task<OperationResult<RolemasterDto>> CreateRoleAsync(RolemasterDto rolemasterDto);
        Task<OperationResult<RolemasterDto>> UpdateRoleAsync(RolemasterDto rolemasterDto);
        Task<OperationResult<RolemasterDto>> GetRoleByIdAsync(long RoleId);
        Task<OperationResult<List<RolemasterDto>>> GetRolesAsync();
        Task<OperationResult<bool>> DeleteRoleAsync(long RoleId);
    }
}
