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
    public interface IMenumasterBusinessLogicProvider
    {
        Task<OperationResult<MenumasterDto>> CreateMenuAsync(MenumasterDto menumasterDto);
        Task<OperationResult<List<MenumasterDto>>> GetMenusAsync();
        Task<OperationResult<MenumasterDto>> UpdateMenuAsync(MenumasterDto menumasterDto);
        Task<OperationResult<MenumasterDto>> GetMenuByIdAsync(long Id);
        Task<OperationResult<bool>> DeleteMenuAsync(long Id);
    }
}
