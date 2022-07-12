using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarGuru.Database.Models;
using CarGuru.Extensions;
using CarGuru.Filters;
using CarGuru.Services.AutoMapper;
using CarGuru.Services.Interfaces;
using CarGuru.Services.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace CarGuru
{
    public class Startup 
    { 
    
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            
            services.AddMvc(config => { config.Filters.Add(new GlobalExceptionFilter()); });
            services.AddServices();
            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Transient);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });

            services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/Login";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
                    options.AccessDeniedPath = "/AccessDenied/Index";
                });
            services.AddAuthorization();
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}
