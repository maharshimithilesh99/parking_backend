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
    public class CompanycontactpersonDataProvider : ICompanycontactpersonDataProvider
    {
        private readonly MplusDbContext _mplusDbContext;
        public CompanycontactpersonDataProvider(MplusDbContext mplusDbContext)
        {
            _mplusDbContext = mplusDbContext;
        }
        public async Task<bool> CreateCompanycontactpersonAsync(CompanycontactpersonDto companycontactpersonDto)
        {
            var Companycontactperson = new Companycontactperson
            {
                ContactPersonId = companycontactpersonDto.ContactPersonId,
                CompanyId = companycontactpersonDto.CompanyId,
                ContactPersonName = companycontactpersonDto.ContactPersonName,
                ContactEmail = companycontactpersonDto.ContactEmail,
                ContactMobile = companycontactpersonDto.ContactMobile,
                Designation = companycontactpersonDto.Designation,
                IsPrimary = companycontactpersonDto.IsPrimary,
                Createdon = DateOnly.FromDateTime(DateTime.UtcNow),
                Createdby = companycontactpersonDto.Createdby,
                ModifyOn= DateOnly.FromDateTime(DateTime.UtcNow),
                Modifyby = companycontactpersonDto.Modifyby,
                IsDeleted=false
            };
            _mplusDbContext.Companycontactperson.Add(Companycontactperson);
            var rowsAffected = await _mplusDbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
        public async Task<CompanycontactpersonDto?> GetByIdAsync(int id)
        {
            return await _mplusDbContext.Companycontactperson
                .Where(x => x.ContactPersonId == id && x.IsDeleted != true)
                .Select(x => new CompanycontactpersonDto
                {
                    ContactPersonId = x.ContactPersonId,
                    CompanyId = x.CompanyId,
                    ContactPersonName = x.ContactPersonName,
                    ContactEmail = x.ContactEmail,
                    ContactMobile = x.ContactMobile,
                    Designation = x.Designation,
                    IsPrimary = x.IsPrimary
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<CompanycontactpersonDto>> GetAllAsync()
        {
            return await _mplusDbContext.Companycontactperson
                .Where(x => x.IsDeleted != true)
                .Select(x => new CompanycontactpersonDto
                {
                    ContactPersonId = x.ContactPersonId,
                    CompanyId = x.CompanyId,
                    ContactPersonName = x.ContactPersonName,
                    ContactEmail = x.ContactEmail,
                    ContactMobile = x.ContactMobile,
                    Designation = x.Designation,
                    IsPrimary = x.IsPrimary
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateCompanycontactpersonAsync(
            CompanycontactpersonDto dto)
        {
            var entity = await _mplusDbContext.Companycontactperson
                .FirstOrDefaultAsync(x =>
                    x.ContactPersonId == dto.ContactPersonId &&
                    x.IsDeleted != true);

            if (entity == null) return false;

            entity.ContactPersonName = dto.ContactPersonName;
            entity.ContactEmail = dto.ContactEmail;
            entity.ContactMobile = dto.ContactMobile;
            entity.Designation = dto.Designation;
            entity.IsPrimary = dto.IsPrimary;
            entity.ModifyOn = DateOnly.FromDateTime(DateTime.UtcNow);
            entity.Modifyby = dto.Modifyby;

            return await _mplusDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCompanycontactpersonAsync(int id)
        {
            var entity = await _mplusDbContext.Companycontactperson
                .FirstOrDefaultAsync(x =>
                    x.ContactPersonId == id &&
                    x.IsDeleted != true);

            if (entity == null) return false;

            entity.IsDeleted = true;
            entity.ModifyOn = DateOnly.FromDateTime(DateTime.UtcNow);

            return await _mplusDbContext.SaveChangesAsync() > 0;
        }
    }
}
