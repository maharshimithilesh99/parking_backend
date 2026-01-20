
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Infrastructure.DTO.Master
{
    public class CompanydocumentDto
    {
        public long DocumentId { get; set; }

        public long CompanyId { get; set; }

        public string? DocumentName { get; set; }

        public string? Documenttype { get; set; }

        public string? Documentpath { get; set; }

        public string? FileFormat { get; set; }

        public DateOnly? ExpiryDate { get; set; }

        public DateOnly? Createdon { get; set; }

        public int Createdby { get; set; }

        public DateOnly? ModifyOn { get; set; }

        public int? Modifyby { get; set; }

        public bool? IsDeleted { get; set; }
        //public IFormFile? DocumentFile { get; set; }

    }
}
