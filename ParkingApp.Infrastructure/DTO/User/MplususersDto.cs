using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Infrastructure.DTO.User
{
    public class MplususersDto
    {
        public long UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string UserCode { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public int Role { get; set; }

        public DateTime? LastLoginAt { get; set; }

        public DateOnly? Createdon { get; set; }

        public int Createdby { get; set; }

        public DateOnly? ModifyOn { get; set; }

        public DateOnly? ModifyBy { get; set; }

        public bool? IsDeleted { get; set; }
        public string? Password { get; set; } = null!;
        public string? RoleName { get; set; }
    }
}
