using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Infrastructure.DTO.User
{
    public class RolemasterDto
    {
        public long Roleid { get; set; }

        public string Rolecode { get; set; } = null!;

        public string Rolename { get; set; } = null!;

        public DateOnly? Createdon { get; set; }

        public int Createdby { get; set; }

        public DateOnly? Modifyon { get; set; }

        public int? Modifyby { get; set; }

        public bool? Isdeleted { get; set; }
    }
}
