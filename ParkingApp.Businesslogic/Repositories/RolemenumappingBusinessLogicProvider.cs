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
    public class RolemenumappingBusinessLogicProvider:IRolemenumappingBusinessLogicProvider
    {
        private IRolemenumappingDataProvider _IRolemenumappingDataProvider;
        private readonly IValidator<RolemenumappingDto> _validator;
        public RolemenumappingBusinessLogicProvider(IRolemenumappingDataProvider rolemenumappingDataProvider, IValidator<RolemenumappingDto> validator)
        {
            _IRolemenumappingDataProvider = rolemenumappingDataProvider;
            _validator = validator;
        }
        public async Task<OperationResult<RolemenumappingDto>> CreateAssignMenusAsync(RolemenumappingDto rolemenumappingDto)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(rolemenumappingDto);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join(", ", validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                    return OperationResult<RolemenumappingDto>.Fail($"Validation failed: {errors}");
                }
                var isCreated = await _IRolemenumappingDataProvider.CreateAssignMenusAsync(rolemenumappingDto);
                if (!isCreated)
                    return OperationResult<RolemenumappingDto>.Fail("Database operation failed: No rows affected");

                return OperationResult<RolemenumappingDto>.Ok(rolemenumappingDto, "Role created successfully");
            }
            catch (DbUpdateException dbEx)
            {
                return OperationResult<RolemenumappingDto>.Fail($"Database error: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                return OperationResult<RolemenumappingDto>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public async Task<OperationResult<bool>> DeleteAssignMenuAsync(long Id)
        {
            var deleted = await _IRolemenumappingDataProvider.DeleteAssignMenuAsync(Id);
            if (!deleted)
                return OperationResult<bool>.Fail("Assign Menus not found");

            return OperationResult<bool>.Ok(true, "Assign Menus deleted successfully");
        }
    }
}
