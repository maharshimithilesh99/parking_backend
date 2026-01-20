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
    public class MenumasterBusinessLogicProvider:IMenumasterBusinessLogicProvider
    {
        private IMenumasterDataProvider _IMenumasterDataProvider;
        private readonly IValidator<MenumasterDto> _validator;
        public MenumasterBusinessLogicProvider(IMenumasterDataProvider menumasterDataProvider, IValidator<MenumasterDto> validator)
        {
            _IMenumasterDataProvider = menumasterDataProvider;
            _validator = validator;
        }
        public async Task<OperationResult<MenumasterDto>> CreateMenuAsync(MenumasterDto menumasterDto)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(menumasterDto);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join(", ", validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                    return OperationResult<MenumasterDto>.Fail($"Validation failed: {errors}");
                }
                var isCreated = await _IMenumasterDataProvider.CreateMenuAsync(menumasterDto);
                if (!isCreated)
                    return OperationResult<MenumasterDto>.Fail("Database operation failed: No rows affected");

                return OperationResult<MenumasterDto>.Ok(menumasterDto, "Menu created successfully");
            }
            catch (DbUpdateException dbEx)
            {
                return OperationResult<MenumasterDto>.Fail($"Database error: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                return OperationResult<MenumasterDto>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public async Task<OperationResult<List<MenumasterDto>>> GetMenusAsync()
        {
            var Menu = await _IMenumasterDataProvider.GetMenusAsync();
            return OperationResult<List<MenumasterDto>>.Ok(Menu, "Menu list fetched successfully");
        }
        public async Task<OperationResult<MenumasterDto>> UpdateMenuAsync(MenumasterDto menumasterDto)
        {
            var updated = await _IMenumasterDataProvider.UpdateMenuAsync(menumasterDto);
            if (!updated)
                return OperationResult<MenumasterDto>.Fail("Role not found or update failed");

            return OperationResult<MenumasterDto>.Ok(menumasterDto, "Menu updated successfully");
        }
        public async Task<OperationResult<MenumasterDto>> GetMenuByIdAsync(long Id)
        {
            var role = await _IMenumasterDataProvider.GetMenuByIdAsync(Id);
            if (role == null)
                return OperationResult<MenumasterDto>.Fail("Menu not found");

            return OperationResult<MenumasterDto>.Ok(role, "Menu fetched successfully");
        }
        public async Task<OperationResult<bool>> DeleteMenuAsync(long Id)
        {
            var deleted = await _IMenumasterDataProvider.DeleteMenuAsync(Id);
            if (!deleted)
                return OperationResult<bool>.Fail("Menu not found");

            return OperationResult<bool>.Ok(true, "Menu deleted successfully");
        }
    }
}
