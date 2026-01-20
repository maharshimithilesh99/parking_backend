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
    public interface IRolemenumappingBusinessLogicProvider
    {
        Task<OperationResult<RolemenumappingDto>> CreateAssignMenusAsync(RolemenumappingDto rolemenumappingDto);
        Task<OperationResult<bool>> DeleteAssignMenuAsync(long Id);
    }
}
