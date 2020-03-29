using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudentDemo.Models;

namespace StudentDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// 容器
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //MVC core 只包含了MVC的核心功能
            //MVC 包含了MVC core 及 其他第三方常用的的方法和服务
            services.AddMvc();
            //services.AddMvcCore();


            //配置依赖服务  3种方法

            services.AddSingleton<IStudent,MoryStudent>();

            //services.AddScoped();

            //services.AddTransient();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            #region
            //异常中间件
            //if (env.IsDevelopment())
            //{
            //    ////自定义设置错误信息
            //    //DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
            //    //developerExceptionPageOptions.SourceCodeLineCount = 1;//错误信息只显示1行
            //    //app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            //    app.UseDeveloperExceptionPage();
            //}

            //DefaultFilesOptions defaultFiles = new DefaultFilesOptions();
            //defaultFiles.DefaultFileNames.Clear();
            //defaultFiles.DefaultFileNames.Add("err.html");

            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("err.html");
            ////UseFileServer结合了UseStaticFiles ，UseDefaultFiles ， usedirectorybrowser 中间件  不推荐使用UseFileServer 容易暴露根目录等信息
            //app.UseFileServer(fileServerOptions);

            ////添加默认文件中间件 必须注册再app.UseStaticFiles();之前
            //app.UseDefaultFiles(defaultFiles);
            ////UseDefaultFiles 中默认支持的页面 index.html index.htm  默认   default.html default.htm

            ////添加静态文件中间件
            //app.UseStaticFiles();

            //添加中间件
            //app.Use(async (context, next) => {
            //    //logger.LogInformation("");
            //    await next();

            //});
            #endregion

            //自定义环境抛出异常
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }else if(env.IsStaging()||env.IsProduction()||env.IsEnvironment("UAT"))
            {
                app.UseExceptionHandler("/err");
            }

            //添加静态文件中间件
            app.UseStaticFiles();
            //MVC带路由等基本配置
            app.UseMvcWithDefaultRoute();
            //MVC
            //app.UseMvc();

            app.Run(async (context) =>
            {
                //throw new Exception("请求发生错误");
                await context.Response.WriteAsync("Host :" + env.EnvironmentName);
            });
        }
    }
}
