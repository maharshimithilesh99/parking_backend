using System;
using System.Collections.Generic;

namespace ParkingApp.Data.Entities;

public partial class Parkingtypemaster
{
    public long Parkingid { get; set; }

    public string Parkingtypename { get; set; } = null!;

    public string Parkingtypecode { get; set; } = null!;

    public string? Description { get; set; }

    public bool Requiresoperator { get; set; }

    public bool Requiresmechanicalsystem { get; set; }

    public DateOnly? Createdon { get; set; }

    public int Createdby { get; set; }

    public DateOnly? Modifyon { get; set; }

    public bool? Isdeleted { get; set; }

    public int? Modifyby { get; set; }
}
