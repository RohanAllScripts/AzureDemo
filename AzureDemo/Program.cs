using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDemo
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
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureAppConfiguration(builder => 
                        { 
                            builder.AddAzureAppConfiguration("Endpoint=https://azuredemoappconfig.azconfig.io;Id=Q7EF;Secret=8rQHJpaJditOEVitEF8nemuLE8+ttF44fJHGt0PQGkw="); 
                        }
                   );
                });
    }
}
