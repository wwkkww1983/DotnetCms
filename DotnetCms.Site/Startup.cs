using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using DotnetCms.Core.Options;
using DotnetCms.Repository.SqlServer;
using DotnetCms.Services;
using DotnetCms.Site.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;

namespace DotnetCms.Site
{
    public class Startup
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            env.ConfigureNLog("NLog.config");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<DbOption>("DotnetCmsOption", Configuration.GetSection("DbOpion"));
            services.AddMemoryCache();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", config =>
            {
                config.Cookie.Name = "Identity.Cooke";
                config.LoginPath = "/Home/Login";
            });

           
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
                options.Cookie.HttpOnly = true;
            });

            services.AddDbContext<AppDbContext>(config => {
                config.UseInMemoryDatabase("Memory");
            });

            services.AddIdentity<IdentityUser, IdentityRole>(config => {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddAntiforgery(options =>
            {
                // Set Cookie properties using CookieBuilder properties†.
                options.FormFieldName = "AntiforgeryKey_dotnet";
                options.HeaderName = "X-CSRF-TOKEN-dotnet";
                options.SuppressXFrameOptionsHeader = false;
            });

            services.AddMvc(option =>
            {
                option.Filters.Add(new GlobalExceptionFilter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //DI了AutoMapper中需要用到的服务，其中包括AutoMapper的配置类 Profile
            services.AddAutoMapper();
            //services.AddSingleton<ScheduleCenter>();

            //Autofac接管DI 
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterAssemblyTypes(typeof(ManagerRoleRepository).Assembly)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(ManagerRoleService).Assembly)
                 .Where(t => t.Name.EndsWith("Service"))
                 .AsImplementedInterfaces();

            return new AutofacServiceProvider(builder.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            try
            {
                //int b = 1;
                //int a = b / 0;
            }
            catch (Exception ex)
            {
                logger.Error(ex, nameof(Startup));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
           
            app.UseSession();
            app.UseAuthentication();
            //add NLog to ASP.NET Core
            loggerFactory.AddNLog();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
