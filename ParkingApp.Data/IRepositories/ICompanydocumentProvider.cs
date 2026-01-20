using ParkingApp.Infrastructure.DTO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.IRepositories
{
    public interface ICompanydocumentProvider
    {
        Task<bool> CreateCompanydocumentAsync(CompanydocumentDto companydocumentDto);
        Task<CompanydocumentDto?> GetByIdAsync(int id);
        Task<List<CompanydocumentDto>> GetAllAsync();
        Task<bool> UpdateCompanydocumentAsync(CompanydocumentDto companydocumentDto);
        Task<bool> DeleteCompanydocumentAsync(int id);
    }
}
