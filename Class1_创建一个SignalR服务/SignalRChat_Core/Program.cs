using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SignalRChat_Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleHelper.WriteSuccessLine("开始启动服务");
            CreateHostBuilder(args).Build().Run();
            ConsoleHelper.WriteSuccessLine("服务启动完毕");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                                          .AddJsonFile("host.json")
                                          .Build();
                    webBuilder.UseUrls("http://*:2233", "http://*:4455");
                    webBuilder.UseConfiguration(configuration);
                    webBuilder.UseStartup<Startup>();
                });
    }
}
