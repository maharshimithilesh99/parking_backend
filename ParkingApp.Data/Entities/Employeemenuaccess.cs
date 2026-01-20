using System;
using System.Collections.Generic;

namespace ParkingApp.Data.Entities;

public partial class Employeemenuaccess
{
    public long Accessid { get; set; }

    public long Userid { get; set; }

    public long Menumasterid { get; set; }

    public bool Canread { get; set; }

    public bool Canwrite { get; set; }

    public bool Candelete { get; set; }

    public DateOnly? Createdon { get; set; }

    public int Createdby { get; set; }

    public DateOnly? Modifyon { get; set; }

    public bool? Isdeleted { get; set; }

    public int? Modifyby { get; set; }
}
