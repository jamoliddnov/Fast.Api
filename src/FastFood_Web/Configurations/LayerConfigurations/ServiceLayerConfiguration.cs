using FastFood_Web.DataAccess.Interfaces.Common;
using FastFood_Web.DataAccess.Repositories.Common;
using FastFood_Web.Service.Common.Security;
using FastFood_Web.Service.Interfaces;
using FastFood_Web.Service.Interfaces.Common;
using FastFood_Web.Service.Services;
using FastFood_Web.Service.Services.Common.EmailServic;
using FastFood_Web.Service.Services.Common.PaginationServic;



namespace FastFood_Web.Api.Configurations.LayerConfigurations
{

    public static class ServiceLayerConfiguration
    {

        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPaginationService, PaginationService>();
            services.AddScoped<ICategoryEmpolyeeService, CategoryEmpolyeeService>();
            services.AddAutoMapper(typeof(MappingConfiguration));
        }
    }
}


//public static void AddService(this IServiceCollection services)
//{
//    services.AddScoped<IAnnouncementService, AnnouncementService>();
//    services.AddScoped<IFileService, FileService>();
//    services.AddScoped<IAuthManagerService, AuthManagerService>();
//    services.AddScoped<IUnitOfWork, UnitOfWork>();
//    services.AddScoped<IPaginatorService, PaginatorService>();
//    services.AddScoped<IAccountService, AccountService>();
//    services.AddScoped<IIdentityService, IdentityService>();
//    services.AddScoped<ICustomerService, CustomerService>();
//    services.AddScoped<IAdminService, AdminService>();
//    services.AddHttpContextAccessor();
//    services.AddAutoMapper(typeof(MappingConfiguration));
//}