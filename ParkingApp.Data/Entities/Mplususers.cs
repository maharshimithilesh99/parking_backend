using System;
using System.Collections.Generic;

namespace ParkingApp.Data.Entities;

public partial class Mplususers
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
}
