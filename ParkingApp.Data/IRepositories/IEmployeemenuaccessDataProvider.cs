using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.IRepositories
{
    public interface IEmployeemenuaccessDataProvider
    {
        Task<bool> AssignMenusToEmployeeAsync(EmployeemenuaccessDto employeemenuaccessDto);
        Task<bool> updateAssignMenusAsync(EmployeemenuaccessDto employeemenuaccessDto);
        Task<EmployeemenuaccessDto?> GetAssignMenusByIdAsync(long Accessid);
        Task<List<EmployeemenuaccessDto>> AssignMenusAsync(int UserId);
        Task<bool> DeleteAssignMenu(long Accessid);
    }
}
