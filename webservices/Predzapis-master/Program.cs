﻿
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SignalR_Vuejs__Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateWebHostBuilder(args).UseIISIntegration().Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
                

    }
}
