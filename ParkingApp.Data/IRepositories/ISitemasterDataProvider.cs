using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.IRepositories
{
    public interface ISitemasterDataProvider
    {
        Task<bool> CreateSiteAsync(SitemasterDto sitemasterDto);
        Task<bool> UpdateSiteAsync(SitemasterDto sitemasterDto);
        Task<SitemasterDto?> GetSiteByIdAsync(long RoleId);
        Task<List<SitemasterDto>> GetSitesAsync();
        Task<bool> DeleteSiteAsync(long RoleId);
    }
}
