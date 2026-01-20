using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Infrastructure.DTO.Master
{
    public class SitemasterDto
    {
        public long Siteid { get; set; }

        public long Companyid { get; set; }

        public string Sitename { get; set; } = null!;

        public string Sitecode { get; set; } = null!;

        public int? Country { get; set; }

        public int? City { get; set; }

        public int? State { get; set; }

        public string Pincode { get; set; } = null!;

        public string Fulladdress { get; set; } = null!;

        public DateOnly Onboardingdate { get; set; }

        public DateOnly Parkingstartdate { get; set; }

        public DateOnly Livedate { get; set; }

        public DateOnly? Contractstartdate { get; set; }

        public DateOnly? Contractenddate { get; set; }

        public int Totalcapacity { get; set; }

        public DateOnly? Createdon { get; set; }

        public int Createdby { get; set; }

        public DateOnly? Modifyon { get; set; }

        public bool? Isdeleted { get; set; }

        public int? Modifyby { get; set; }
    }
}
