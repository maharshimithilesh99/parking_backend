using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Businesslogic.Helpers;
using ParkingApp.Businesslogic.IRepositories;
using ParkingApp.Data.IRepositories;
using ParkingApp.Data.Repository;
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Businesslogic.Repositories
{
    public class EmployeemenuaccessBusinessLogicProvider:IEmployeemenuaccessBusinessLogicProvider
    {
        private IEmployeemenuaccessDataProvider _IEmployeemenuaccessDataProvider;
        private readonly IValidator<EmployeemenuaccessDto> _validator;
        public EmployeemenuaccessBusinessLogicProvider(IEmployeemenuaccessDataProvider employeemenuaccessDataProvider, IValidator<EmployeemenuaccessDto> validator)
        {
            _IEmployeemenuaccessDataProvider = employeemenuaccessDataProvider;
            _validator = validator;
        }
        public async Task<OperationResult<EmployeemenuaccessDto>> AssignMenusToEmployeeAsync(EmployeemenuaccessDto employeemenuaccessDto)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(employeemenuaccessDto);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join(", ", validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                    return OperationResult<EmployeemenuaccessDto>.Fail($"Validation failed: {errors}");
                }
                var isCreated = await _IEmployeemenuaccessDataProvider.AssignMenusToEmployeeAsync(employeemenuaccessDto);
                if (!isCreated)
                    return OperationResult<EmployeemenuaccessDto>.Fail("Database operation failed: No rows affected");

                return OperationResult<EmployeemenuaccessDto>.Ok(employeemenuaccessDto, "Menu Assign to employee created successfully");
            }
            catch (DbUpdateException dbEx)
            {
                return OperationResult<EmployeemenuaccessDto>.Fail($"Database error: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                return OperationResult<EmployeemenuaccessDto>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public async Task<OperationResult<EmployeemenuaccessDto>> updateAssignMenusAsync(EmployeemenuaccessDto employeemenuaccessDto)
        {
            var updated = await _IEmployeemenuaccessDataProvider.updateAssignMenusAsync(employeemenuaccessDto);
            if (!updated)
                return OperationResult<EmployeemenuaccessDto>.Fail("Assign Menu not found or update failed");

            return OperationResult<EmployeemenuaccessDto>.Ok(employeemenuaccessDto, "Assign Menu updated successfully");
        }
        public async Task<OperationResult<EmployeemenuaccessDto>> GetAssignMenusByIdAsync(long Accessid)
        {
            var role = await _IEmployeemenuaccessDataProvider.GetAssignMenusByIdAsync(Accessid);
            if (role == null)
                return OperationResult<EmployeemenuaccessDto>.Fail("Assign Menus not found");

            return OperationResult<EmployeemenuaccessDto>.Ok(role, "Assign Menus fetched successfully");
        }
        public async Task<OperationResult<List<EmployeemenuaccessDto>>> AssignMenusAsync(int UserId)
        {
            var AssignMenus = await _IEmployeemenuaccessDataProvider.AssignMenusAsync(UserId);
            return OperationResult<List<EmployeemenuaccessDto>>.Ok(AssignMenus, "Assign Menus list fetched successfully");
        }
        public async Task<OperationResult<bool>> DeleteAssignMenu(long Accessid)
        {
            var deleted = await _IEmployeemenuaccessDataProvider.DeleteAssignMenu(Accessid);
            if (!deleted)
                return OperationResult<bool>.Fail("Assign Menus not found");

            return OperationResult<bool>.Ok(true, "Assign Menus deleted successfully");
        }
    }
}
