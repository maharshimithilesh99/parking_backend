using ParkingApp.Businesslogic.Helpers;
using ParkingApp.Infrastructure.DTO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Businesslogic.IRepositories
{
    public interface ICompanyBusinessLogicProvider
    {
        Task<OperationResult<CompanymasterDto>> CreateCompanyAsync(CompanymasterDto companyDto);
        Task<OperationResult<CompanymasterDto>> UpdateCompanyAsync(CompanymasterDto companyDto);
        Task<OperationResult<bool>> DeleteCompanyAsync(long companyId);
        Task<OperationResult<CompanymasterDto>> GetCompanyByIdAsync(long companyId);
        Task<OperationResult<List<CompanymasterDto>>> GetCompaniesAsync();
        Task<OperationResult<List<EnumResult>>> GetStatusesAsync();
        Task<OperationResult<List<CompanyTypeDto>>> GetCompanyTypesAsync();
        Task<OperationResult<bool>> CheckcompanyCode(string CompanyCode);
    }
}
