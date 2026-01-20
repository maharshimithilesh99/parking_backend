using ParkingApp.Infrastructure.DTO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.IRepositories
{
    public interface ICompanycontactpersonDataProvider
    {
        Task<bool> CreateCompanycontactpersonAsync(CompanycontactpersonDto companycontactpersonDto);
        Task<CompanycontactpersonDto> GetByIdAsync(int id);
        Task<List<CompanycontactpersonDto>> GetAllAsync();
        Task<bool> UpdateCompanycontactpersonAsync(CompanycontactpersonDto dto);
        Task<bool> DeleteCompanycontactpersonAsync(int id);
    }
}
