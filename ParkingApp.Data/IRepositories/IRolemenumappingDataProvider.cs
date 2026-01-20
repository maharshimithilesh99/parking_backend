using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.IRepositories
{
    public interface IRolemenumappingDataProvider
    {
        Task<bool> CreateAssignMenusAsync(RolemenumappingDto rolemenumappingDto);
        Task<bool> DeleteAssignMenuAsync(long Id);
    }
}
