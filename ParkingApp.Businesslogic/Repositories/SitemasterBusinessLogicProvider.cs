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
    public class SitemasterBusinessLogicProvider:ISitemasterBusinessLogicProvider
    {
        private ISitemasterDataProvider _ISitemasterDataProvider;
        private readonly IValidator<SitemasterDto> _validator;
        public SitemasterBusinessLogicProvider(ISitemasterDataProvider sitemasterDataProvider, IValidator<SitemasterDto> validator)
        {
            _ISitemasterDataProvider = sitemasterDataProvider;
            _validator = validator;
        }
        public async Task<OperationResult<SitemasterDto>> CreateSiteAsync(SitemasterDto sitemasterDto)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(sitemasterDto);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join(", ", validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                    return OperationResult<SitemasterDto>.Fail($"Validation failed: {errors}");
                }
                var isCreated = await _ISitemasterDataProvider.CreateSiteAsync(sitemasterDto);
                if (!isCreated)
                    return OperationResult<SitemasterDto>.Fail("Database operation failed: No rows affected");

                return OperationResult<SitemasterDto>.Ok(sitemasterDto, "Site created successfully");
            }
            catch (DbUpdateException dbEx)
            {
                return OperationResult<SitemasterDto>.Fail($"Database error: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                return OperationResult<SitemasterDto>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public async Task<OperationResult<SitemasterDto>> UpdateSiteAsync(SitemasterDto sitemasterDto)
        {
            var updated = await _ISitemasterDataProvider.UpdateSiteAsync(sitemasterDto);
            if (!updated)
                return OperationResult<SitemasterDto>.Fail("Site not found or update failed");

            return OperationResult<SitemasterDto>.Ok(sitemasterDto, "Site updated successfully");
        }
        public async Task<OperationResult<SitemasterDto>> GetSiteByIdAsync(long SiteId)
        {
            var role = await _ISitemasterDataProvider.GetSiteByIdAsync(SiteId);
            if (role == null)
                return OperationResult<SitemasterDto>.Fail("Site not found");

            return OperationResult<SitemasterDto>.Ok(role, "Site fetched successfully");
        }
        public async Task<OperationResult<List<SitemasterDto>>> GetSitesAsync()
        {
            var sitemaster = await _ISitemasterDataProvider.GetSitesAsync();
            return OperationResult<List<SitemasterDto>>.Ok(sitemaster, "Site list fetched successfully");
        }
        public async Task<OperationResult<bool>> DeleteSiteAsync(long SiteId)
        {
            var deleted = await _ISitemasterDataProvider.DeleteSiteAsync(SiteId);
            if (!deleted)
                return OperationResult<bool>.Fail("Site not found");

            return OperationResult<bool>.Ok(true, "Site deleted successfully");
        }
    }
}
