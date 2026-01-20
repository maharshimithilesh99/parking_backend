using ParkingApp.Businesslogic.Helpers;
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Businesslogic.IRepositories
{
    public interface ISitemasterBusinessLogicProvider
    {
        Task<OperationResult<SitemasterDto>> CreateSiteAsync(SitemasterDto sitemasterDto);
        Task<OperationResult<SitemasterDto>> UpdateSiteAsync(SitemasterDto sitemasterDto);
        Task<OperationResult<SitemasterDto>> GetSiteByIdAsync(long SiteId);
        Task<OperationResult<List<SitemasterDto>>> GetSitesAsync();
        Task<OperationResult<bool>> DeleteSiteAsync(long SiteId);
    }
}
