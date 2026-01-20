using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Infrastructure.DTO.Master
{
    public class RolemenumappingDto
    {
        public long Roleid { get; set; }

        public long Menuid { get; set; }

        public DateOnly? Createdon { get; set; }

        public int Createdby { get; set; }

        public DateOnly? Modifyon { get; set; }

        public bool? Isdeleted { get; set; }

        public long Rolemenuid { get; set; }

        public int? Modifyby { get; set; }
    }
}
