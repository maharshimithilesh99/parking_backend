using Microsoft.Extensions.DependencyInjection;
using ParkingApp.Businesslogic.IRepositories;
using ParkingApp.Businesslogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Businesslogic.UnitOfWorkExtensions
{
    public static class BusinessLogicServiceExtensions
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyBusinessLogicProvider, CompanyBusinessLogicProvider>();
            services.AddScoped<ICompanydocumentBusinessLogicProvider, CompanydocumentBusinessLogicProvider>();
            services.AddScoped<ICompanycontactpersonBusinessLogicProvider, CompanycontactpersonBusinessLogicProvider>();
            services.AddScoped<IMplususersBusinessLogicProvider, MplususersBusinessLogicProvider>();
            services.AddScoped<IRolemasterBusinessLogicProvider, RolemasterBusinessLogicProvider>();
            services.AddScoped<IMenumasterBusinessLogicProvider, MenumasterBusinessLogicProvider>();
            services.AddScoped<IRolemenumappingBusinessLogicProvider, RolemenumappingBusinessLogicProvider>();
            services.AddScoped<IEmployeemenuaccessBusinessLogicProvider, EmployeemenuaccessBusinessLogicProvider>();
            services.AddScoped<ISitemasterBusinessLogicProvider, SitemasterBusinessLogicProvider>();
            return services;
            //return services.AddScoped<ICompanyBusinessLogicProvider, CompanyBusinessLogicProvider>();
        }
    }
}
