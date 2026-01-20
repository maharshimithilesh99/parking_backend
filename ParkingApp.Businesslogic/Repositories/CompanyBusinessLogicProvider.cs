
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Businesslogic.Helpers;
using ParkingApp.Businesslogic.IRepositories;
using ParkingApp.Data.Entities;
using ParkingApp.Data.IRepositories;
using ParkingApp.Data.Repository;
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.Master.Enum;

namespace ParkingApp.Businesslogic.Repositories
{
    public class CompanyBusinessLogicProvider : ICompanyBusinessLogicProvider
    {
        private ICompanyDataProvider _ICompanyDataProvider;
        private readonly IValidator<CompanymasterDto> _validator;
        public CompanyBusinessLogicProvider(ICompanyDataProvider companyDataProvider, IValidator<CompanymasterDto> validator)
        {
            _ICompanyDataProvider = companyDataProvider;
            _validator = validator;
        }
        public async Task<OperationResult<CompanymasterDto>> CreateCompanyAsync(CompanymasterDto companyDto)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(companyDto);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join(", ", validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                    return OperationResult<CompanymasterDto>.Fail($"Validation failed: {errors}");
                }
                var isCreated = await _ICompanyDataProvider.CreateCompanyAsync(companyDto);
                if (!isCreated)
                    return OperationResult<CompanymasterDto>.Fail("Database operation failed: No rows affected");
               
                return OperationResult<CompanymasterDto>.Ok(companyDto, "Company created successfully");
            }
            catch (DbUpdateException dbEx)
            {
                return OperationResult<CompanymasterDto>.Fail($"Database error: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                return OperationResult<CompanymasterDto>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public async Task<OperationResult<CompanymasterDto>> UpdateCompanyAsync(CompanymasterDto companyDto)
        {
            var updated = await _ICompanyDataProvider.UpdateCompanyAsync(companyDto);
            if (!updated)
                return OperationResult<CompanymasterDto>.Fail("Company not found or update failed");

            return OperationResult<CompanymasterDto>.Ok(companyDto, "Company updated successfully");
        }
        public async Task<OperationResult<bool>> DeleteCompanyAsync(long companyId)
        {
            var deleted = await _ICompanyDataProvider.DeleteCompanyAsync(companyId);
            if (!deleted)
                return OperationResult<bool>.Fail("Company not found");

            return OperationResult<bool>.Ok(true, "Company deleted successfully");
        }
        public async Task<OperationResult<CompanymasterDto>> GetCompanyByIdAsync(long companyId)
        {
            var company = await _ICompanyDataProvider.GetCompanyByIdAsync(companyId);
            if (company == null)
                return OperationResult<CompanymasterDto>.Fail("Company not found");

            return OperationResult<CompanymasterDto>.Ok(company, "Company fetched successfully");
        }
        public async Task<OperationResult<List<CompanymasterDto>>> GetCompaniesAsync()
        {
            var companies = await _ICompanyDataProvider.GetCompaniesAsync();
            return OperationResult<List<CompanymasterDto>>.Ok(companies, "Company list fetched successfully");
        }
        public async Task<OperationResult<List<EnumResult>>> GetStatusesAsync()
        {
            try
            {
                var statuses = await _ICompanyDataProvider.GetStatusesAsync();

                if (statuses == null || statuses.Count == 0)
                {
                    return OperationResult<List<EnumResult>>
                        .Fail("No statuses found");
                }

                return OperationResult<List<EnumResult>>
                    .Ok(statuses, "Status list fetched successfully");
            }
            catch (Exception ex)
            {
                return OperationResult<List<EnumResult>>
                    .Fail("Unexpected error occurred");
            }
        }
        public async Task<OperationResult<List<CompanyTypeDto>>> GetCompanyTypesAsync()
        {
            try
            {
                var companyTypes = Enum.GetValues(typeof(CompanyType))
                    .Cast<CompanyType>()
                    .Select(e => new CompanyTypeDto
                    {
                        Id = (int)e,
                        Name = e.ToString().Replace("ITPark", "IT Park")
                    })
                    .ToList();

                return OperationResult<List<CompanyTypeDto>>
                    .Ok(companyTypes, "Company types fetched successfully");
            }
            catch (Exception ex)
            {
                return OperationResult<List<CompanyTypeDto>>
                    .Fail("Failed to fetch company types");
            }
        }
        public async Task<OperationResult<bool>> CheckcompanyCode(string CompanyCode)
        {
            var deleted = await _ICompanyDataProvider.CheckcompanyCode(CompanyCode);
            if (!deleted)
                return OperationResult<bool>.Fail("Company not found");

            return OperationResult<bool>.Ok(true, "Company code find successfully");
        }

    }
}
