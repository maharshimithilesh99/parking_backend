using System;
using System.Collections.Generic;

namespace ParkingApp.Data.Entities;

public partial class Companydocument
{
    public long DocumentId { get; set; }

    public long CompanyId { get; set; }

    public string? DocumentName { get; set; }

    public string? Documenttype { get; set; }

    public string? Documentpath { get; set; }

    public string? FileFormat { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public DateOnly? Createdon { get; set; }

    public int Createdby { get; set; }

    public DateOnly? ModifyOn { get; set; }

    public bool? IsDeleted { get; set; }

    public int? Modifyby { get; set; }
}
