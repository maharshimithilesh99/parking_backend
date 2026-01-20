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
    public interface IMplususersBusinessLogicProvider
    {
        Task<OperationResult<MplususersDto>> CreateUserAsync(MplususersDto mplususersDto);
        Task<OperationResult<LoginResponseDto>> UserLoginAsync(UserLogin userLogin);
        Task<OperationResult<List<MplususersDto>>> GetUsersAsync();
        Task<OperationResult<MplususersDto>> GetUserByIdAsync(long id);
        Task<OperationResult<bool>> DeleteUserAsync(long Id);
    }
}
