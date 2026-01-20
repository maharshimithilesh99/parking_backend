using ParkingApp.Businesslogic.Helpers;
using ParkingApp.Infrastructure.DTO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Businesslogic.IRepositories
{
    public interface ICompanycontactpersonBusinessLogicProvider
    {
        Task<OperationResult<CompanycontactpersonDto>> CreateCompanycontactpersonAsync(CompanycontactpersonDto companycontactpersonDto);
        Task<OperationResult<CompanycontactpersonDto>> GetCompanycontactpersonByIdAsync(int id);
        Task<OperationResult<List<CompanycontactpersonDto>>> GetCompanycontactpersonsAsync();
        Task<OperationResult<CompanycontactpersonDto>> UpdateCompanycontactpersonAsync(
            CompanycontactpersonDto dto);
        Task<OperationResult<bool>> DeleteCompanycontactpersonAsync(int id);
        
    }
}
