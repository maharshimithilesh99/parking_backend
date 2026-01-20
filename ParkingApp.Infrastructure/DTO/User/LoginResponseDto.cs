using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Infrastructure.DTO.User
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = null!;
        public string? TokenType { get; set; }
        public DateTime ExpiresAt { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; } = null!;
        public int Role { get; set; }
        public string? RoleName { get; set; }
        public List<ParentMenuDto> ParentMenus { get; set; } = new();
    }
    public class ParentMenuDto
    {
        public long MenuId { get; set; }
        public string MenuName { get; set; } = null!;
        public string? Icon { get; set; }
        public List<ChildMenuDto> Children { get; set; } = new();
    }

    public class ChildMenuDto
    {
        public long MenuId { get; set; }
        public string MenuName { get; set; } = null!;
        public string? RoutePath { get; set; }
        public string? Icon { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanDelete { get; set; }
    }

}
