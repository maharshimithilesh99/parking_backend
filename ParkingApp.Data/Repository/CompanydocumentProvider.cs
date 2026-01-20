using Microsoft.EntityFrameworkCore;
using ParkingApp.Data.Context;
using ParkingApp.Data.Entities;
using ParkingApp.Data.IRepositories;
using ParkingApp.Infrastructure.DTO.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ParkingApp.Data.Repository
{
    public class CompanydocumentProvider: ICompanydocumentProvider
    {
        private readonly MplusDbContext _mplusDbContext;
        public CompanydocumentProvider(MplusDbContext mplusDbContext)
        {
            _mplusDbContext = mplusDbContext;
        }
        public async Task<bool> CreateCompanydocumentAsync(CompanydocumentDto companydocumentDto)
        {
            var Companydocument = new Companydocument
            {
                DocumentId = companydocumentDto.DocumentId,
                CompanyId = companydocumentDto.CompanyId,
                DocumentName = companydocumentDto.DocumentName,
                Documenttype = companydocumentDto.Documenttype,
                Documentpath = companydocumentDto.Documentpath,
                FileFormat = companydocumentDto.FileFormat,
                ExpiryDate = companydocumentDto.ExpiryDate,
                Createdon = DateOnly.FromDateTime(DateTime.UtcNow),
                Createdby = companydocumentDto.Createdby,
                ModifyOn = DateOnly.FromDateTime(DateTime.UtcNow),
                Modifyby = companydocumentDto.Modifyby,
                IsDeleted = false
            };
            _mplusDbContext.Companydocument.Add(Companydocument);
            var rowsAffected = await _mplusDbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
        public async Task<CompanydocumentDto?> GetByIdAsync(int id)
        {
            return await _mplusDbContext.Companydocument
                .Where(x => x.IsDeleted != true && x.DocumentId == id)
                .Select(x => new CompanydocumentDto
                {
                    DocumentId = x.DocumentId,
                    CompanyId = x.CompanyId,
                    DocumentName = x.DocumentName,
                    Documenttype = x.Documenttype,
                    Documentpath = x.Documentpath,
                    FileFormat = x.FileFormat,
                    ExpiryDate = x.ExpiryDate
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<CompanydocumentDto>> GetAllAsync()
        {
            return await _mplusDbContext.Companydocument
                .Where(x => x.IsDeleted !=true)
                .Select(x => new CompanydocumentDto
                {
                    DocumentId = x.DocumentId,
                    CompanyId = x.CompanyId,
                    DocumentName = x.DocumentName,
                    Documenttype = x.Documenttype,
                    Documentpath = x.Documentpath,
                    FileFormat = x.FileFormat,
                    ExpiryDate = x.ExpiryDate
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateCompanydocumentAsync(CompanydocumentDto companydocumentDto)
        {
            var entity = await _mplusDbContext.Companydocument
                .FirstOrDefaultAsync(x => x.DocumentId == companydocumentDto.DocumentId && x.IsDeleted != true);

            if (entity == null) return false;
            entity.CompanyId = companydocumentDto.CompanyId;
            entity.DocumentName = companydocumentDto.DocumentName;
            entity.Documenttype = companydocumentDto.Documenttype;
            entity.Documentpath = companydocumentDto.Documentpath;
            entity.FileFormat = companydocumentDto.FileFormat;
            entity.ExpiryDate = companydocumentDto.ExpiryDate;
            entity.ModifyOn = DateOnly.FromDateTime(DateTime.UtcNow);
            entity.Modifyby = companydocumentDto.Modifyby;

            return await _mplusDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCompanydocumentAsync(int id)
        {
            var entity = await _mplusDbContext.Companydocument
                .FirstOrDefaultAsync(x => x.DocumentId == id && x.IsDeleted != true);

            if (entity == null) return false;

            entity.IsDeleted = true;
            entity.ModifyOn = DateOnly.FromDateTime(DateTime.UtcNow);

            return await _mplusDbContext.SaveChangesAsync() > 0;
        }

    }
}
