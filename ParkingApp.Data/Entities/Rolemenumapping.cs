using System;
using System.Collections.Generic;

namespace ParkingApp.Data.Entities;

public partial class Rolemenumapping
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
