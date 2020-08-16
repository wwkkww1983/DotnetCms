using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCms.Admin.Filter;
using DotnetCms.Admin.Validation;
using DotnetCms.Core.Options;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;

namespace DotnetCms.Admin
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DbOption>("DotnetCmsOption", Configuration.GetSection("DbOpion"));
            services.AddMemoryCache();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

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
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
              .AddControllersAsServices()
              .AddFluentValidation(fv =>
              {
                  //程序集方式引入
                  fv.RegisterValidatorsFromAssemblyContaining<ManagerRoleValidation>();
                  //去掉其他的验证，只使用FluentValidation的验证规则
                  fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
              }); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
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
                int b = 1;
                int a = b / 0;
            }
            catch (Exception ex)
            {
                logger.Error(ex, nameof(Startup));
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

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
