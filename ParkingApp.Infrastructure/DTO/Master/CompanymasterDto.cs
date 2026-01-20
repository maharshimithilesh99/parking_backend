using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Infrastructure.DTO.Master
{
    public class CompanymasterDto
    {
        public long CompanyId { get; set; }

        public string CompanyName { get; set; } = null!;

        public string CompanyCode { get; set; } = null!;

        public int CompanyType { get; set; }

        public string RegisteredAddress { get; set; } = null!;

        public string? Gstnumber { get; set; }

        public string? Pannumber { get; set; }

        public DateOnly? OnboardingDate { get; set; }

        public DateOnly? Createdon { get; set; }

        public int Createdby { get; set; }

        public DateOnly? ModifyOn { get; set; }

        public int? Modifyby { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
