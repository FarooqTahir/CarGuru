using AutoMapper;
using CarGuru.Api.Extensions;
using CarGuru.Api.Filters;
using CarGuru.Api.Middleware;
using CarGuru.Api.Utility;
using CarGuru.Database.Models;
using CarGuru.Filters;
using CarGuru.Services.AutoMapper;
using CarGuru.Services.Interfaces;
using CarGuru.Services.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CarGuru.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var mvcBuilder = services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILookUpsService, LookupService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IFleetService, FleetService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeTypeService, EmployeeTypeService>();
            services.AddTransient<ICustomerTypeService, CustomerTypeService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IVendorService, VendorService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddScoped<IQuotationService, QuotationService>();
            services.AddScoped<IConversationService, ConversationService>();
            services.AddScoped<IHangleLog, HandleLogs>(); 
            services.AddScoped<IFeedbackService, FeedbackService>(); 
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IManagementService, ManagementService>();
            services.AddScoped<ISessionManager, SessionManager>(); 
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<APILog>();
            services.AddScoped<StripeAPI>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
  .AddJwtBearer(x =>
  {
      x.RequireHttpsMetadata = false;
      x.SaveToken = true;
      x.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"])),
          ValidateIssuer = false,
          ValidateAudience = false,
      };
  });
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
            //options =>
            //{
            //options.LoginPath = new PathString("/api/Login/Login");
            //options.AccessDeniedPath = new PathString("/api/Login/Login");
            //});

            //    services.AddAuthentication()
            //        .AddCookie(options => {
            //            options.LoginPath = "/api/Login/Login";
            //            options.AccessDeniedPath = "/api/Login/Login";
            //        }).AddJwtBearer(options => {
            //    options.Audience = "http://localhost:44308/";
            //    options.Authority = "http://localhost:44309/";
            //});
            services.AddTransient<IAttendanceService, AttendaceService>();
            services.AddTransient<IServiceOrderService, ServiceOrderService>();
            services.AddHttpContextAccessor();
            services.AddMvc(
                config =>
                {
                    config.Filters.Add(typeof(GlobalExceptionFilter));
                }).AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.PropertyNamingPolicy = null;
                    o.JsonSerializerOptions.DictionaryKeyPolicy = null;

                }).AddMvcOptions(options =>
                {
                    options.Filters.Add<APILog>();
                })
    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1); 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
                        },
                        new string[] {}
                    }
                });
            });
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });


            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();

            //Add our new middleware to the pipeline
            //app.UseMiddleware<RequestResponseLoggingMiddleware>();
            //app.UseRequestResponseLogging();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.Use(async (context, next) =>
            //{
            //    context.Request.EnableBuffering();
            //    await next();
            //});
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Index}/{id?}");
            });



        }
    }
}
