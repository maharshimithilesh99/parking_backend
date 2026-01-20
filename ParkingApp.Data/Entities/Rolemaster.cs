using System;
using System.Collections.Generic;

namespace ParkingApp.Data.Entities;

public partial class Rolemaster
{
    public long Roleid { get; set; }

    public string Rolecode { get; set; } = null!;

    public string Rolename { get; set; } = null!;

    public DateOnly? Createdon { get; set; }

    public int Createdby { get; set; }

    public DateOnly? Modifyon { get; set; }

    public bool? Isdeleted { get; set; }

    public int? Modifyby { get; set; }
}
