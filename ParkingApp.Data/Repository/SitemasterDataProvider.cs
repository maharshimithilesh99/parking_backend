using Microsoft.EntityFrameworkCore;
using ParkingApp.Data.Context;
using ParkingApp.Data.Entities;
using ParkingApp.Data.IRepositories;
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.Repository
{
    public class SitemasterDataProvider:ISitemasterDataProvider
    {
        private readonly MplusDbContext _mplusDbContext;
        public SitemasterDataProvider(MplusDbContext mplusDbContext)
        {
            _mplusDbContext = mplusDbContext;
        }
        public async Task<bool> CreateSiteAsync(SitemasterDto sitemasterDto)
        {
            var Sitemaster = new Sitemaster
            {
                Companyid = sitemasterDto.Companyid,
                Sitename = sitemasterDto.Sitename,
                Sitecode = sitemasterDto.Sitecode,
                Country = sitemasterDto.Country,
                City = sitemasterDto.City,
                State = sitemasterDto.State,
                Pincode = sitemasterDto.Pincode,
                Fulladdress = sitemasterDto.Fulladdress,
                Onboardingdate = sitemasterDto.Onboardingdate,
                Parkingstartdate = sitemasterDto.Parkingstartdate,
                Livedate = sitemasterDto.Livedate,
                Contractstartdate = sitemasterDto.Contractstartdate,
                Contractenddate = sitemasterDto.Contractenddate,
                Totalcapacity = sitemasterDto.Totalcapacity,
                Createdon = DateOnly.FromDateTime(DateTime.UtcNow),
                Createdby = sitemasterDto.Createdby,
                Modifyon = DateOnly.FromDateTime(DateTime.UtcNow),
                Modifyby = sitemasterDto.Modifyby,
                Isdeleted = false
            };
            _mplusDbContext.Sitemaster.Add(Sitemaster);
            var rowsAffected = await _mplusDbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
        public async Task<bool> UpdateSiteAsync(SitemasterDto sitemasterDto)
        {
            var Sitemaster = await _mplusDbContext.Sitemaster
                .FirstOrDefaultAsync(x => x.Siteid == sitemasterDto.Siteid);

            if (Sitemaster == null)
                return false;

            Sitemaster.Companyid = sitemasterDto.Companyid;
            Sitemaster.Sitename = sitemasterDto.Sitename;
            Sitemaster.Sitecode = sitemasterDto.Sitecode;
            Sitemaster.Country = sitemasterDto.Country;
            Sitemaster.City = sitemasterDto.City;
            Sitemaster.State = sitemasterDto.State;
            Sitemaster.Pincode = sitemasterDto.Pincode;
            Sitemaster.Fulladdress = sitemasterDto.Fulladdress;
            Sitemaster.Onboardingdate = sitemasterDto.Onboardingdate;
            Sitemaster.Parkingstartdate = sitemasterDto.Parkingstartdate;
            Sitemaster.Livedate = sitemasterDto.Livedate;
            Sitemaster.Contractstartdate = sitemasterDto.Contractstartdate;
            Sitemaster.Contractenddate = sitemasterDto.Contractenddate;
            Sitemaster.Totalcapacity = sitemasterDto.Totalcapacity;
            Sitemaster.Modifyby = sitemasterDto.Modifyby;
            Sitemaster.Modifyon = DateOnly.FromDateTime(DateTime.UtcNow);
            return await _mplusDbContext.SaveChangesAsync() > 0;
        }
        public async Task<SitemasterDto?> GetSiteByIdAsync(long SiteId)
        {
            return await _mplusDbContext.Sitemaster
                .Where(x => x.Siteid == SiteId)
                .Select(x => new SitemasterDto
                {
                    Siteid = x.Siteid,
                    Companyid = x.Companyid,
                    Sitename = x.Sitename,
                    Sitecode = x.Sitecode,
                    Country = x.Country,
                    City = x.City,
                    State = x.State,
                    Pincode = x.Pincode,
                    Fulladdress = x.Fulladdress,
                    Onboardingdate = x.Onboardingdate,
                    Parkingstartdate = x.Parkingstartdate,
                    Livedate = x.Livedate,
                    Contractstartdate = x.Contractstartdate,
                    Contractenddate = x.Contractenddate,
                    Totalcapacity = x.Totalcapacity,

                })
                .FirstOrDefaultAsync();
        }
        public async Task<List<SitemasterDto>> GetSitesAsync()
        {
            return await _mplusDbContext.Sitemaster.Where(m => m.Isdeleted == false)
                .Select(x => new SitemasterDto
                {
                    Siteid = x.Siteid,
                    Companyid = x.Companyid,
                    Sitename = x.Sitename,
                    Sitecode = x.Sitecode,
                    Country = x.Country,
                    City = x.City,
                    State = x.State,
                    Pincode = x.Pincode,
                    Fulladdress = x.Fulladdress,
                    Onboardingdate = x.Onboardingdate,
                    Parkingstartdate = x.Parkingstartdate,
                    Livedate = x.Livedate,
                    Contractstartdate = x.Contractstartdate,
                    Contractenddate = x.Contractenddate,
                    Totalcapacity = x.Totalcapacity,
                })
                .ToListAsync();
        }
        public async Task<bool> DeleteSiteAsync(long SiteId)
        {
            var Sitemaster = await _mplusDbContext.Sitemaster
                .FirstOrDefaultAsync(x => x.Siteid == SiteId);

            if (Sitemaster == null)
                return false;

            Sitemaster.Isdeleted = true;
            Sitemaster.Modifyon = DateOnly.FromDateTime(DateTime.UtcNow);
            return await _mplusDbContext.SaveChangesAsync() > 0;
        }
    }
}
