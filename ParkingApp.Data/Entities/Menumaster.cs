using System;
using System.Collections.Generic;

namespace ParkingApp.Data.Entities;

public partial class Menumaster
{
    public long Menumasterid { get; set; }

    public string Menuname { get; set; } = null!;

    public string Menutype { get; set; } = null!;

    public long Parentid { get; set; }

    public string? Routepath { get; set; }

    public string? Icon { get; set; }

    public int Displayorder { get; set; }

    public DateOnly? Createdon { get; set; }

    public int Createdby { get; set; }

    public DateOnly? Modifyon { get; set; }

    public bool? Isdeleted { get; set; }

    public int? Modifyby { get; set; }
}
