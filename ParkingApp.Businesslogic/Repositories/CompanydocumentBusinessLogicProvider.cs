
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
    public class CompanydocumentBusinessLogicProvider : ICompanydocumentBusinessLogicProvider
    {
        private ICompanydocumentProvider _ICompanydocumentProvider;
        private readonly IValidator<CompanydocumentDto> _validator;
        public CompanydocumentBusinessLogicProvider(ICompanydocumentProvider companydocumentProvider, IValidator<CompanydocumentDto> validator)
        {
            _ICompanydocumentProvider = companydocumentProvider;
            _validator = validator;
        }
        public async Task<OperationResult<CompanydocumentDto>> CreateCompanydocumentAsync(CompanydocumentDto companydocumentDto)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(companydocumentDto);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join(", ", validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                    return OperationResult<CompanydocumentDto>.Fail($"Validation failed: {errors}");
                }
                //if (companydocumentDto.DocumentFile == null || companydocumentDto.DocumentFile.Length == 0)
                //{
                //    return OperationResult<CompanydocumentDto>.Fail("Document file is required");
                //}

                //#region Upload Company Document
                //var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(),"Uploads","CompanyDocuments");
                //if (!Directory.Exists(uploadsFolder))
                //    Directory.CreateDirectory(uploadsFolder);

                //var uniqueFileName =$"{Guid.NewGuid()}{Path.GetExtension(companydocumentDto.DocumentFile.FileName)}";
                //var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                //using (var stream = new FileStream(filePath, FileMode.Create))
                //{
                //    await companydocumentDto.DocumentFile.CopyToAsync(stream);
                //}
                //companydocumentDto.Documentpath = uniqueFileName;
                //#endregion
                var isCreated = await _ICompanydocumentProvider.CreateCompanydocumentAsync(companydocumentDto);
                if (!isCreated)
                    return OperationResult<CompanydocumentDto>.Fail("Database operation failed: No rows affected");
               
                return OperationResult<CompanydocumentDto>.Ok(companydocumentDto, "Company Document created successfully");
            }
            catch (DbUpdateException dbEx)
            {
                return OperationResult<CompanydocumentDto>.Fail($"Database error: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                return OperationResult<CompanydocumentDto>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public async Task<OperationResult<CompanydocumentDto>> GetCompanydocumentByIdAsync(int id)
        {
            var data = await _ICompanydocumentProvider.GetByIdAsync(id);
            return data == null
                ? OperationResult<CompanydocumentDto>.Fail("Not found")
                : OperationResult<CompanydocumentDto>.Ok(data);
        }

        public async Task<OperationResult<List<CompanydocumentDto>>> GetCompanydocumentsAsync()
        {
            var list = await _ICompanydocumentProvider.GetAllAsync();
            return OperationResult<List<CompanydocumentDto>>.Ok(list);
        }

        public async Task<OperationResult<CompanydocumentDto>> UpdateCompanydocumentAsync(
            CompanydocumentDto companydocumentDto)
        {
            var success = await _ICompanydocumentProvider.UpdateCompanydocumentAsync(companydocumentDto);
            return success
                ? OperationResult<CompanydocumentDto>.Ok(companydocumentDto, "Updated successfully")
                : OperationResult<CompanydocumentDto>.Fail("Update failed");
        }

        public async Task<OperationResult<bool>> DeleteCompanydocumentAsync(int id)
        {
            var success = await _ICompanydocumentProvider.DeleteCompanydocumentAsync(id);
            return success
                ? OperationResult<bool>.Ok(true, "Deleted successfully")
                : OperationResult<bool>.Fail("Delete failed");
        }
    }
}
