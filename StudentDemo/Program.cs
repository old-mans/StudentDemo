using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace StudentDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
        #region 添加lon4net 日志
            //.ConfigureLogging((context, loggingBuilder) =>
            //{
            //    loggingBuilder.AddFilter("System", LogLevel.Warning);//过滤命名空间
            //    loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
            //    loggingBuilder.AddLog4Net();
            //})
        #endregion
                .UseStartup<Startup>();
    }
}
