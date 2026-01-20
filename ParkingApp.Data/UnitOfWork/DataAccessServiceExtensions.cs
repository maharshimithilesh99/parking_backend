using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using ParkingApp.Data.Context;
using ParkingApp.Data.Infrastructure;
using ParkingApp.Data.IRepositories;
using ParkingApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.UnitOfWork
{
    public static class DataAccessServiceExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection  services)
        {
            services.AddScoped<ICompanyDataProvider, CompanyDataProvider>();
            services.AddScoped<ICompanydocumentProvider, CompanydocumentProvider>();
            services.AddScoped<ICompanycontactpersonDataProvider, CompanycontactpersonDataProvider>();
            services.AddScoped<IMplususersDataProvider, MplususersDataProvider>();
            services.AddScoped<IRolemasterDataProvider, RolemasterDataProvider>();
            services.AddScoped<IMenumasterDataProvider, MenumasterDataProvider>();
            services.AddScoped<IRolemenumappingDataProvider, RolemenumappingDataProvider>();
            services.AddScoped<IEmployeemenuaccessDataProvider, EmployeemenuaccessDataProvider>();
            services.AddScoped<ISitemasterDataProvider, SitemasterDataProvider>();
            return services;
            //return services.AddScoped<ICompanyDataProvider,CompanyDataProvider>();
        }
        public static IServiceCollection AddMplusDbContext(this IServiceCollection services,DbConnectionEntities? dbConnectionEntities)
        {
            if (dbConnectionEntities == null)
                throw new ArgumentNullException(nameof(dbConnectionEntities));

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = dbConnectionEntities.ServerName,
                Port = dbConnectionEntities.Port,
                Database = dbConnectionEntities.DatabaseName,
                Username = dbConnectionEntities.UserName,
                Password = dbConnectionEntities.Password,
                IncludeErrorDetail = true
            };

            return services.AddDbContextPool<MplusDbContext>(options =>
                options.UseNpgsql(builder.ConnectionString));
        }

    }
}
