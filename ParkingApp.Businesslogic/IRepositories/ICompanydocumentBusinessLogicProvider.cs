using ParkingApp.Businesslogic.Helpers;
using ParkingApp.Infrastructure.DTO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Businesslogic.IRepositories
{
    public interface ICompanydocumentBusinessLogicProvider
    {
        Task<OperationResult<CompanydocumentDto>> CreateCompanydocumentAsync(CompanydocumentDto companydocumentDto);
        Task<OperationResult<CompanydocumentDto>> GetCompanydocumentByIdAsync(int id);
        Task<OperationResult<List<CompanydocumentDto>>> GetCompanydocumentsAsync();
        Task<OperationResult<CompanydocumentDto>> UpdateCompanydocumentAsync(CompanydocumentDto companydocumentDto);
        Task<OperationResult<bool>> DeleteCompanydocumentAsync(int id);
    }
}
