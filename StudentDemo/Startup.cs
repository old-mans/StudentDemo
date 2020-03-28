﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace StudentDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            //异常中间件
            //if (env.IsDevelopment())
            //{
            //    ////自定义设置错误信息
            //    //DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
            //    //developerExceptionPageOptions.SourceCodeLineCount = 1;//错误信息只显示1行
            //    //app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            //    app.UseDeveloperExceptionPage();
            //}
            #region

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


            app.Run(async (context) =>
            {
                //throw new Exception("请求发生错误");
                await context.Response.WriteAsync("Host :" + env.EnvironmentName);
            });
        }
    }
}
