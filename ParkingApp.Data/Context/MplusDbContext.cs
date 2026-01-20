using Microsoft.EntityFrameworkCore;
using ParkingApp.Data.Entities;
using ParkingApp.Infrastructure.DTO.Master;
using System;
using System.Collections.Generic;

namespace ParkingApp.Data.Context;

public partial class MplusDbContext : DbContext
{
    public MplusDbContext()
    {
    }

    public MplusDbContext(DbContextOptions<MplusDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Companycontactperson> Companycontactperson { get; set; }

    public virtual DbSet<Companydocument> Companydocument { get; set; }

    public virtual DbSet<Companymaster> Companymaster { get; set; }

    public virtual DbSet<Employeemenuaccess> Employeemenuaccess { get; set; }

    public virtual DbSet<Menumaster> Menumaster { get; set; }

    public virtual DbSet<Mplususers> Mplususers { get; set; }

    public virtual DbSet<Parkingtypemaster> Parkingtypemaster { get; set; }

    public virtual DbSet<Rolemaster> Rolemaster { get; set; }

    public virtual DbSet<Rolemenumapping> Rolemenumapping { get; set; }

    public virtual DbSet<Sitefloormaster> Sitefloormaster { get; set; }

    public virtual DbSet<Sitemaster> Sitemaster { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("sitetype", new[] { "Mall", "Street", "Basement", "Hospital" })
            .HasPostgresEnum("status", new[] { "Active", "Inactive", "Pending", "Blacklist" });

        modelBuilder.Entity<Companycontactperson>(entity =>
        {
            entity.HasKey(e => e.ContactPersonId).HasName("companycontactperson_pkey");

            entity.ToTable("companycontactperson");

            entity.Property(e => e.ContactPersonId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ContactPersonID");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(200)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.ContactMobile)
                .HasMaxLength(150)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.ContactPersonName)
                .HasMaxLength(150)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.Createdon).HasDefaultValueSql("CURRENT_DATE");
            entity.Property(e => e.Designation)
                .HasMaxLength(200)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.IsPrimary).HasDefaultValue(false);
            entity.Property(e => e.Modifyby).HasColumnName("modifyby");
        });

        modelBuilder.Entity<Companydocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("companydocument_pkey");

            entity.ToTable("companydocument");

            entity.Property(e => e.DocumentId).UseIdentityAlwaysColumn();
            entity.Property(e => e.Createdon).HasDefaultValueSql("CURRENT_DATE");
            entity.Property(e => e.DocumentName)
                .HasMaxLength(150)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.Documentpath)
                .HasMaxLength(1000)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.Documenttype)
                .HasMaxLength(20)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.FileFormat)
                .HasMaxLength(20)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Modifyby).HasColumnName("modifyby");
        });

        modelBuilder.Entity<Companymaster>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("companymaster_pkey");

            entity.ToTable("companymaster");

            entity.HasIndex(e => e.CompanyCode, "companymaster_CompanyCode_key").IsUnique();

            entity.Property(e => e.CompanyId).UseIdentityAlwaysColumn();
            entity.Property(e => e.CompanyCode).HasMaxLength(100);
            entity.Property(e => e.CompanyName).HasMaxLength(150);
            entity.Property(e => e.Createdon).HasDefaultValueSql("CURRENT_DATE");
            entity.Property(e => e.Gstnumber)
                .HasMaxLength(150)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("GSTNumber");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Modifyby).HasColumnName("modifyby");
            entity.Property(e => e.OnboardingDate).HasDefaultValueSql("CURRENT_DATE");
            entity.Property(e => e.Pannumber)
                .HasMaxLength(150)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("PANNumber");
        });

        modelBuilder.Entity<Employeemenuaccess>(entity =>
        {
            entity.HasKey(e => e.Accessid).HasName("employeemenuaccess_pkey");

            entity.ToTable("employeemenuaccess");

            entity.Property(e => e.Accessid).HasColumnName("accessid");
            entity.Property(e => e.Candelete)
                .HasDefaultValue(false)
                .HasColumnName("candelete");
            entity.Property(e => e.Canread)
                .HasDefaultValue(false)
                .HasColumnName("canread");
            entity.Property(e => e.Canwrite)
                .HasDefaultValue(false)
                .HasColumnName("canwrite");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("createdon");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Menumasterid).HasColumnName("menumasterid");
            entity.Property(e => e.Modifyby).HasColumnName("modifyby");
            entity.Property(e => e.Modifyon).HasColumnName("modifyon");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Menumaster>(entity =>
        {
            entity.HasKey(e => e.Menumasterid).HasName("menumaster_pkey");

            entity.ToTable("menumaster");

            entity.Property(e => e.Menumasterid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("menumasterid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("createdon");
            entity.Property(e => e.Displayorder)
                .HasDefaultValue(1)
                .HasColumnName("displayorder");
            entity.Property(e => e.Icon)
                .HasMaxLength(100)
                .HasColumnName("icon");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Menuname)
                .HasMaxLength(100)
                .HasColumnName("menuname");
            entity.Property(e => e.Menutype)
                .HasMaxLength(20)
                .HasColumnName("menutype");
            entity.Property(e => e.Modifyby).HasColumnName("modifyby");
            entity.Property(e => e.Modifyon).HasColumnName("modifyon");
            entity.Property(e => e.Parentid).HasColumnName("parentid");
            entity.Property(e => e.Routepath)
                .HasMaxLength(255)
                .HasColumnName("routepath");
        });

        modelBuilder.Entity<Mplususers>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("mplususers_pkey");

            entity.ToTable("mplususers");

            entity.HasIndex(e => e.UserCode, "mplususers_UserCode_key").IsUnique();

            entity.Property(e => e.UserId).UseIdentityAlwaysColumn();
            entity.Property(e => e.Createdon).HasDefaultValueSql("CURRENT_DATE");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.PasswordHash).HasColumnName("Password_hash");
            entity.Property(e => e.UserCode).HasMaxLength(150);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<Parkingtypemaster>(entity =>
        {
            entity.HasKey(e => e.Parkingid).HasName("parkingtypemaster_pkey");

            entity.ToTable("parkingtypemaster");

            entity.HasIndex(e => e.Parkingtypecode, "parkingtypemaster_parkingtypecode_key").IsUnique();

            entity.Property(e => e.Parkingid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("parkingid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("createdon");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modifyby).HasColumnName("modifyby");
            entity.Property(e => e.Modifyon).HasColumnName("modifyon");
            entity.Property(e => e.Parkingtypecode)
                .HasMaxLength(30)
                .HasColumnName("parkingtypecode");
            entity.Property(e => e.Parkingtypename)
                .HasMaxLength(100)
                .HasColumnName("parkingtypename");
            entity.Property(e => e.Requiresmechanicalsystem)
                .HasDefaultValue(true)
                .HasColumnName("requiresmechanicalsystem");
            entity.Property(e => e.Requiresoperator)
                .HasDefaultValue(true)
                .HasColumnName("requiresoperator");
        });

        modelBuilder.Entity<Rolemaster>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("rolemaster_pkey");

            entity.ToTable("rolemaster");

            entity.HasIndex(e => e.Rolecode, "rolemaster_rolecode_key").IsUnique();

            entity.Property(e => e.Roleid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("roleid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("createdon");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modifyby).HasColumnName("modifyby");
            entity.Property(e => e.Modifyon).HasColumnName("modifyon");
            entity.Property(e => e.Rolecode)
                .HasMaxLength(50)
                .HasColumnName("rolecode");
            entity.Property(e => e.Rolename)
                .HasMaxLength(100)
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<Rolemenumapping>(entity =>
        {
            entity.HasKey(e => e.Rolemenuid).HasName("rolemenumapping_pk");

            entity.ToTable("rolemenumapping");

            entity.Property(e => e.Rolemenuid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("rolemenuid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("createdon");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Menuid).HasColumnName("menuid");
            entity.Property(e => e.Modifyby).HasColumnName("modifyby");
            entity.Property(e => e.Modifyon).HasColumnName("modifyon");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
        });

        modelBuilder.Entity<Sitefloormaster>(entity =>
        {
            entity.HasKey(e => e.Floorid).HasName("sitefloormaster_pkey");

            entity.ToTable("sitefloormaster");

            entity.Property(e => e.Floorid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("floorid");
            entity.Property(e => e.Companyid).HasColumnName("companyid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("createdon");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Entrypoints)
                .HasDefaultValue(0)
                .HasColumnName("entrypoints");
            entity.Property(e => e.Evcharging)
                .HasDefaultValue(false)
                .HasColumnName("evcharging");
            entity.Property(e => e.Exitpoints)
                .HasDefaultValue(0)
                .HasColumnName("exitpoints");
            entity.Property(e => e.Floorcode)
                .HasMaxLength(20)
                .HasColumnName("floorcode");
            entity.Property(e => e.Floorlevel).HasColumnName("floorlevel");
            entity.Property(e => e.Floorname)
                .HasMaxLength(100)
                .HasColumnName("floorname");
            entity.Property(e => e.Floortype)
                .HasMaxLength(30)
                .HasColumnName("floortype");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modifyby).HasColumnName("modifyby");
            entity.Property(e => e.Modifyon).HasColumnName("modifyon");
            entity.Property(e => e.Siteid).HasColumnName("siteid");
            entity.Property(e => e.Startdate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("startdate");
            entity.Property(e => e.Totalcapacity)
                .HasDefaultValue(0)
                .HasColumnName("totalcapacity");
        });

        modelBuilder.Entity<Sitemaster>(entity =>
        {
            entity.HasKey(e => e.Siteid).HasName("sitemaster_pkey");

            entity.ToTable("sitemaster");

            entity.HasIndex(e => e.Sitecode, "sitemaster_sitecode_key").IsUnique();

            entity.Property(e => e.Siteid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("siteid");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Companyid).HasColumnName("companyid");
            entity.Property(e => e.Contractenddate).HasColumnName("contractenddate");
            entity.Property(e => e.Contractstartdate).HasColumnName("contractstartdate");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("createdon");
            entity.Property(e => e.Fulladdress).HasColumnName("fulladdress");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Livedate).HasColumnName("livedate");
            entity.Property(e => e.Modifyby).HasColumnName("modifyby");
            entity.Property(e => e.Modifyon).HasColumnName("modifyon");
            entity.Property(e => e.Onboardingdate).HasColumnName("onboardingdate");
            entity.Property(e => e.Parkingstartdate).HasColumnName("parkingstartdate");
            entity.Property(e => e.Pincode)
                .HasMaxLength(10)
                .HasColumnName("pincode");
            entity.Property(e => e.Sitecode)
                .HasMaxLength(50)
                .HasColumnName("sitecode");
            entity.Property(e => e.Sitename)
                .HasMaxLength(150)
                .HasColumnName("sitename");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.Totalcapacity)
                .HasDefaultValue(0)
                .HasColumnName("totalcapacity");
        });
        modelBuilder.Entity<EnumResult>().HasNoKey();
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
