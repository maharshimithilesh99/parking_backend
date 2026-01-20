using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.IRepositories
{
    public interface IMenumasterDataProvider
    {
        Task<bool> CreateMenuAsync(MenumasterDto menumasterDto);
        Task<bool> UpdateMenuAsync(MenumasterDto menumasterDto);
        Task<List<MenumasterDto>> GetMenusAsync();
        Task<MenumasterDto?> GetMenuByIdAsync(long Id);
        Task<bool> DeleteMenuAsync(long Id);
    }
}
