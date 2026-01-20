using ParkingApp.Data.Entities;
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.IRepositories
{
    public interface IMplususersDataProvider
    {
        Task<bool> CreateUserAsync(MplususersDto companydto);
        Task<MplususersDto?> UserLoginAsync(UserLogin userLogin);
        Task<List<ParentMenuDto>> GetMenusByRoleAsync(int roleId);
        Task<List<ParentMenuDto>> GetMenusByRoleOrEmployeeAsync(int roleId, long userId);
        Task<List<MplususersDto>> GetUsersAsync();
        Task<MplususersDto?> GetUserByIdAsync(long Id);
        Task<bool> DeleteUserAsync(long Id);
    }
}
