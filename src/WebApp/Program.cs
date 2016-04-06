using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = WebHostConfiguration.GetDefault(args);
            
                var host = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(configuration)
                .UseServer("Microsoft.AspNetCore.Server.Kestrel")
                .UseKestrel()
                .UseIISPlatformHandlerUrl()
                .Build();

                host.Run();
           
            
        }
    }
}
