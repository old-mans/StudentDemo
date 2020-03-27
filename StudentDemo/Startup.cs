using System;
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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //DefaultFilesOptions defaultFiles = new DefaultFilesOptions();
            //defaultFiles.DefaultFileNames.Clear();
            //defaultFiles.DefaultFileNames.Add("err.html");

            FileServerOptions fileServerOptions = new FileServerOptions();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("err.html");
            //UseFileServer结合了UseStaticFiles ，UseDefaultFiles ， usedirectorybrowser 中间件  不推荐使用UseFileServer 容易暴露根目录等信息
            app.UseFileServer(fileServerOptions);

            #region
            ////添加默认文件中间件 必须注册再app.UseStaticFiles();之前
            //app.UseDefaultFiles(defaultFiles);
            ////UseDefaultFiles 中默认支持的页面 index.html index.htm  默认   default.html default.htm

            ////添加静态文件中间件
            //app.UseStaticFiles();
            #endregion




            #region
            //添加中间件
            //app.Use(async (context, next) => {
            //    //logger.LogInformation("");
            //    await next();

            //});
            #endregion



            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
