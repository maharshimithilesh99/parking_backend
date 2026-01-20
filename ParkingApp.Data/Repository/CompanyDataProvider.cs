using Microsoft.EntityFrameworkCore;
using ParkingApp.Data.Context;
using ParkingApp.Data.Entities;
using ParkingApp.Data.IRepositories;
using ParkingApp.Infrastructure.DTO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.Repository
{
    public class CompanyDataProvider : ICompanyDataProvider
    {
        private readonly MplusDbContext _mplusDbContext;
        public CompanyDataProvider(MplusDbContext mplusDbContext)
        {
            _mplusDbContext = mplusDbContext;
        }
        public async Task<bool> CreateCompanyAsync(CompanymasterDto companyDto)
        {
            var Companymaster = new Companymaster
            {
                CompanyId = companyDto.CompanyId,
                CompanyName = companyDto.CompanyName,
                CompanyCode = companyDto.CompanyCode,
                CompanyType = companyDto.CompanyType,
                RegisteredAddress = companyDto.RegisteredAddress,
                Gstnumber = companyDto.Gstnumber,
                Pannumber = companyDto.Pannumber,
                OnboardingDate = companyDto.OnboardingDate,
                Createdon = DateOnly.FromDateTime(DateTime.UtcNow),
                Createdby =companyDto.Createdby,
                ModifyOn= DateOnly.FromDateTime(DateTime.UtcNow),
                Modifyby = companyDto.Modifyby,
                IsDeleted=false
            };
            _mplusDbContext.Companymaster.Add(Companymaster);
            var rowsAffected = await _mplusDbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
        public async Task<bool> UpdateCompanyAsync(CompanymasterDto companyDto)
        {
            var company = await _mplusDbContext.Companymaster
                .FirstOrDefaultAsync(x => x.CompanyId == companyDto.CompanyId);

            if (company == null)
                return false;

            company.CompanyName = companyDto.CompanyName;
            company.CompanyCode = companyDto.CompanyCode;
            company.CompanyType = companyDto.CompanyType;
            company.RegisteredAddress = companyDto.RegisteredAddress;
            company.Gstnumber = companyDto.Gstnumber;
            company.Pannumber = companyDto.Pannumber;
            company.OnboardingDate = companyDto.OnboardingDate;
            company.Modifyby = companyDto.Modifyby;
            company.ModifyOn = DateOnly.FromDateTime(DateTime.UtcNow);
            return await _mplusDbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteCompanyAsync(long companyId)
        {
            var company = await _mplusDbContext.Companymaster
                .FirstOrDefaultAsync(x => x.CompanyId == companyId);

            if (company == null)
                return false;

            company.IsDeleted = true;
            company.ModifyOn= DateOnly.FromDateTime(DateTime.UtcNow);
            return await _mplusDbContext.SaveChangesAsync() > 0;
        }
        public async Task<CompanymasterDto?> GetCompanyByIdAsync(long companyId)
        {
            return await _mplusDbContext.Companymaster
                .Where(x => x.CompanyId == companyId)
                .Select(x => new CompanymasterDto
                {
                    CompanyId = x.CompanyId,
                    CompanyName = x.CompanyName,
                    CompanyCode = x.CompanyCode,
                    CompanyType = x.CompanyType,
                    RegisteredAddress = x.RegisteredAddress,
                    Gstnumber = x.Gstnumber,
                    Pannumber = x.Pannumber,
                    OnboardingDate = x.OnboardingDate
                })
                .FirstOrDefaultAsync();
        }
        public async Task<List<CompanymasterDto>> GetCompaniesAsync()
        {
            return await _mplusDbContext.Companymaster.Where(m =>m.IsDeleted==false)
                .Select(x => new CompanymasterDto
                {
                    CompanyId = x.CompanyId,
                    CompanyName = x.CompanyName,
                    CompanyCode = x.CompanyCode,
                    CompanyType = x.CompanyType,
                    RegisteredAddress = x.RegisteredAddress,
                    Gstnumber = x.Gstnumber,
                    Pannumber = x.Pannumber,
                    OnboardingDate = x.OnboardingDate
                })
                .ToListAsync();
        }
        public async Task<List<EnumResult>> GetStatusesAsync()
        {
            return await _mplusDbContext
                .Set<EnumResult>()
                .FromSqlRaw("SELECT unnest(enum_range(NULL::public.status)) AS Value")
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<bool> CheckcompanyCode(string companyCode)
        {
            return await _mplusDbContext.Companymaster
                .AnyAsync(x =>
                    x.CompanyCode.ToLower() == companyCode.ToLower() &&
                    x.IsDeleted==false);
        }



    }
}
