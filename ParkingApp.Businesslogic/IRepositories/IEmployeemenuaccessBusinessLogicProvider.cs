using ParkingApp.Businesslogic.Helpers;
using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Businesslogic.IRepositories
{
    public interface IEmployeemenuaccessBusinessLogicProvider
    {
        Task<OperationResult<EmployeemenuaccessDto>> AssignMenusToEmployeeAsync(EmployeemenuaccessDto employeemenuaccessDto);
        Task<OperationResult<EmployeemenuaccessDto>> updateAssignMenusAsync(EmployeemenuaccessDto employeemenuaccessDto);
        Task<OperationResult<EmployeemenuaccessDto>> GetAssignMenusByIdAsync(long Accessid);
        Task<OperationResult<List<EmployeemenuaccessDto>>> AssignMenusAsync(int Userid);
        Task<OperationResult<bool>> DeleteAssignMenu(long Accessid);
    }
}
