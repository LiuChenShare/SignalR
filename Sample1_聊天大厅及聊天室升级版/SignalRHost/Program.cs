using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SignalRHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    if (File.Exists("SignalRHost.json"))
                    {
                        var configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                                                 .AddJsonFile("SignalRHost.json")
                                                 .Build();
                        //webBuilder.UseUrls("http://*:2233", "http://*:4455");
                        webBuilder.UseConfiguration(configuration);
                    }
                    else
                    {
                        webBuilder.UseUrls("http://*:777", "http://*:778");
                    }
                    webBuilder.UseStartup<Startup>();
                    ConsoleHelper.WriteSuccessLine("SignalRHost������");
                });
    }
}
