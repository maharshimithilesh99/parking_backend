using ParkingApp.Data.Entities;
using ParkingApp.Infrastructure.DTO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.IRepositories
{
    public interface ICompanyDataProvider
    {
        Task<bool> CreateCompanyAsync(CompanymasterDto companydto);
        Task<bool> UpdateCompanyAsync(CompanymasterDto companyDto);
        Task<bool> DeleteCompanyAsync(long companyId);
        Task<CompanymasterDto?> GetCompanyByIdAsync(long companyId);
        Task<List<CompanymasterDto>> GetCompaniesAsync();
        Task<List<EnumResult>> GetStatusesAsync();
        Task<bool> CheckcompanyCode(string CompanyCode);
    }
}
