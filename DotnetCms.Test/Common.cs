/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：N/A                                                    
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/16 23:14:00                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.Test                                 
*│　类    名： Common                                      
*└──────────────────────────────────────────────────────────────┘
*/

using DotnetCms.Core.CodeGenerator;
using DotnetCms.Core.Helper;
using DotnetCms.Core.Models;
using DotnetCms.Core.Options;
using DotnetCms.Core.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCms.Test
{
    public class Common
    {
        /// <summary>
        /// 构造依赖注入容器，然后传入参数
        /// </summary>
        /// <returns></returns>
        public static IServiceProvider BuildServiceForSqlServer()
        {
            var services = new ServiceCollection();
            services.Configure<CodeGenerateOption>(options =>
            {
                /*options.ConnectionString = "Data Source=192.168.1.118;Initial Catalog=Rnrs;User ID=sa;Password=Ahph65167235;Persist Security Info=True;Max Pool Size=50;Min Pool Size=0;Connection Lifetime=300;";*/

                options.ConnectionString = "Data Source=.;Initial Catalog=CzarCms;User ID=sa;Password=zsy980314;Persist Security Info=True;Max Pool Size=50;Min Pool Size=0;Connection Lifetime=300;";

                options.DbType = DatabaseType.SqlServer.ToString();//数据库类型是SqlServer,其他数据类型参照枚举DatabaseType
                options.Author = "zhengshengyi";//作者名称
                options.OutputPath = "e:\\CodeGenerator";//模板代码生成的路径
                options.ModelsNamespace = "DotnetCms.Models";//实体命名空间
                options.IRepositoryNamespace = "DotnetCms.IRepository";//仓储接口命名空间
                options.RepositoryNamespace = "DotnetCms.Repository.SqlServer";//仓储命名空间
                options.IServicesNamespace = "DotnetCms.IServices";//服务接口命名空间
                options.ServicesNamespace = "DotnetCms.Services";//服务命名空间


            });
            services.Configure<DbOption>("DotnetCmsOption", GetConfiguration().GetSection("DbOpion"));
            //services.AddScoped<IArticleRepository, ArticleRepository>();
            //services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CodeGenerator>();
            services.AddLogging();
            services.AddSingleton<DelegateHelper>();
            return services.BuildServiceProvider(); //构建服务提供程序
        }

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
