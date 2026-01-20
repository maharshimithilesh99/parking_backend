
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Businesslogic.Helpers;
using ParkingApp.Businesslogic.IRepositories;
using ParkingApp.Data.Entities;
using ParkingApp.Data.IRepositories;
using ParkingApp.Data.Repository;
using ParkingApp.Infrastructure.DTO.Master;

namespace ParkingApp.Businesslogic.Repositories
{
    public class CompanycontactpersonBusinessLogicProvider : ICompanycontactpersonBusinessLogicProvider
    {
        private ICompanycontactpersonDataProvider _ICompanycontactpersonDataProvider;
        private readonly IValidator<CompanycontactpersonDto> _validator;
        public CompanycontactpersonBusinessLogicProvider(ICompanycontactpersonDataProvider companycontactpersonDataProvider, IValidator<CompanycontactpersonDto> validator)
        {
            _ICompanycontactpersonDataProvider = companycontactpersonDataProvider;
            _validator = validator;
        }
        public async Task<OperationResult<CompanycontactpersonDto>> CreateCompanycontactpersonAsync(CompanycontactpersonDto companycontactpersonDto)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(companycontactpersonDto);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join(", ", validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                    return OperationResult<CompanycontactpersonDto>.Fail($"Validation failed: {errors}");
                }
                var isCreated = await _ICompanycontactpersonDataProvider.CreateCompanycontactpersonAsync(companycontactpersonDto);
                if (!isCreated)
                    return OperationResult<CompanycontactpersonDto>.Fail("Database operation failed: No rows affected");
               
                return OperationResult<CompanycontactpersonDto>.Ok(companycontactpersonDto, "Company Contact person created successfully");
            }
            catch (DbUpdateException dbEx)
            {
                return OperationResult<CompanycontactpersonDto>.Fail($"Database error: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                return OperationResult<CompanycontactpersonDto>.Fail($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<CompanycontactpersonDto>> GetCompanycontactpersonByIdAsync(int id)
        {
            var data = await _ICompanycontactpersonDataProvider.GetByIdAsync(id);
            return data == null
                ? OperationResult<CompanycontactpersonDto>.Fail("Not found")
                : OperationResult<CompanycontactpersonDto>.Ok(data);
        }
        public async Task<OperationResult<List<CompanycontactpersonDto>>>GetCompanycontactpersonsAsync()
        {
            var list = await _ICompanycontactpersonDataProvider.GetAllAsync();
            return OperationResult<List<CompanycontactpersonDto>>.Ok(list);
        }
        public async Task<OperationResult<CompanycontactpersonDto>>UpdateCompanycontactpersonAsync(CompanycontactpersonDto dto)
        {
            var success = await _ICompanycontactpersonDataProvider.UpdateCompanycontactpersonAsync(dto);

            return success
                ? OperationResult<CompanycontactpersonDto>.Ok(dto, "Updated successfully")
                : OperationResult<CompanycontactpersonDto>.Fail("Update failed");
        }
        public async Task<OperationResult<bool>>DeleteCompanycontactpersonAsync(int id)
        {
            var success = await _ICompanycontactpersonDataProvider.DeleteCompanycontactpersonAsync(id);

            return success
                ? OperationResult<bool>.Ok(true, "Deleted successfully")
                : OperationResult<bool>.Fail("Delete failed");
        }
    }
}
