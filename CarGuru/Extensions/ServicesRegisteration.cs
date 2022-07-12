using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using CarGuru.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarGuru.Extensions
{
    public static class ServicesRegisteration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<ILookUpsService, LookupService>();
            services.AddTransient<ILoginService, LoginService>();
           // services.AddTransient<ISessionManager, SessionManager>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeTypeService, EmployeeTypeService>();
            services.AddTransient<ICustomerTypeService, CustomerTypeService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IVendorService, VendorService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IFleetService, FleetService>();
            services.AddTransient<IServiceOrderService, ServiceOrderService>();
            services.AddTransient<IQuotationService, QuotationService>();
            services.AddScoped<IManualCallRecordService, ManualCallRecordService>();
            services.AddScoped<ISessionManager, SessionManager>();
            services.AddScoped<IQuotationService, QuotationService>();
            services.AddScoped<IConversationService, ConversationService>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IManagementService, ManagementService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
        }
    }
}