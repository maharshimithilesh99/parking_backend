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
    public class RolemasterBusinessLogicProvider:IRolemasterBusinessLogicProvider
    {
        private IRolemasterDataProvider _IRolemasterDataProvider;
        private readonly IValidator<RolemasterDto> _validator;
        public RolemasterBusinessLogicProvider(IRolemasterDataProvider rolemasterDataProvider, IValidator<RolemasterDto> validator)
        {
            _IRolemasterDataProvider = rolemasterDataProvider;
            _validator = validator;
        }
        public async Task<OperationResult<RolemasterDto>> CreateRoleAsync(RolemasterDto rolemasterDto)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(rolemasterDto);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join(", ", validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                    return OperationResult<RolemasterDto>.Fail($"Validation failed: {errors}");
                }
                var isCreated = await _IRolemasterDataProvider.CreateRoleAsync(rolemasterDto);
                if (!isCreated)
                    return OperationResult<RolemasterDto>.Fail("Database operation failed: No rows affected");

                return OperationResult<RolemasterDto>.Ok(rolemasterDto, "Role created successfully");
            }
            catch (DbUpdateException dbEx)
            {
                return OperationResult<RolemasterDto>.Fail($"Database error: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                return OperationResult<RolemasterDto>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public async Task<OperationResult<RolemasterDto>> UpdateRoleAsync(RolemasterDto rolemasterDto)
        {
            var updated = await _IRolemasterDataProvider.UpdateRoleAsync(rolemasterDto);
            if (!updated)
                return OperationResult<RolemasterDto>.Fail("Role not found or update failed");

            return OperationResult<RolemasterDto>.Ok(rolemasterDto, "Role updated successfully");
        }
        public async Task<OperationResult<RolemasterDto>> GetRoleByIdAsync(long RoleId)
        {
            var role = await _IRolemasterDataProvider.GetRoleByIdAsync(RoleId);
            if (role == null)
                return OperationResult<RolemasterDto>.Fail("Role not found");

            return OperationResult<RolemasterDto>.Ok(role, "Role fetched successfully");
        }
        public async Task<OperationResult<List<RolemasterDto>>> GetRolesAsync()
        {
            var companies = await _IRolemasterDataProvider.GetRolesAsync();
            return OperationResult<List<RolemasterDto>>.Ok(companies, "Role list fetched successfully");
        }
        public async Task<OperationResult<bool>> DeleteRoleAsync(long RoleId)
        {
            var deleted = await _IRolemasterDataProvider.DeleteRoleAsync(RoleId);
            if (!deleted)
                return OperationResult<bool>.Fail("Role not found");

            return OperationResult<bool>.Ok(true, "Role deleted successfully");
        }
    }
}
