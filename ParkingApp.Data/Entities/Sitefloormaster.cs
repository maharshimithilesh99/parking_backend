using System;
using System.Collections.Generic;

namespace ParkingApp.Data.Entities;

public partial class Sitefloormaster
{
    public long Floorid { get; set; }

    public long Companyid { get; set; }

    public long Siteid { get; set; }

    public string Floorname { get; set; } = null!;

    public string Floorcode { get; set; } = null!;

    public int Floorlevel { get; set; }

    public string? Floortype { get; set; }

    public int Totalcapacity { get; set; }

    public int? Entrypoints { get; set; }

    public int? Exitpoints { get; set; }

    public bool? Evcharging { get; set; }

    public DateOnly Startdate { get; set; }

    public DateOnly? Enddate { get; set; }

    public DateOnly? Createdon { get; set; }

    public int Createdby { get; set; }

    public DateOnly? Modifyon { get; set; }

    public bool? Isdeleted { get; set; }

    public int? Modifyby { get; set; }
}
