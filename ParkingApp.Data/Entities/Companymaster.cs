using System;
using System.Collections.Generic;

namespace ParkingApp.Data.Entities;

public partial class Companymaster
{
    public long CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyCode { get; set; } = null!;

    public int CompanyType { get; set; }

    public string RegisteredAddress { get; set; } = null!;

    public string? Gstnumber { get; set; }

    public string? Pannumber { get; set; }

    public DateOnly? OnboardingDate { get; set; }

    public DateOnly? Createdon { get; set; }

    public int Createdby { get; set; }

    public DateOnly? ModifyOn { get; set; }

    public bool? IsDeleted { get; set; }

    public int? Modifyby { get; set; }
}
