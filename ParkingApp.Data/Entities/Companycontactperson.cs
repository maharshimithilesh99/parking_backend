using System;
using System.Collections.Generic;

namespace ParkingApp.Data.Entities;

public partial class Companycontactperson
{
    public long ContactPersonId { get; set; }

    public long CompanyId { get; set; }

    public string? ContactPersonName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactMobile { get; set; }

    public string? Designation { get; set; }

    public bool? IsPrimary { get; set; }

    public DateOnly? Createdon { get; set; }

    public int Createdby { get; set; }

    public DateOnly? ModifyOn { get; set; }

    public bool? IsDeleted { get; set; }

    public int? Modifyby { get; set; }
}
