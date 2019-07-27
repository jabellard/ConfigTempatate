using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConfigTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateCustomWebHostBuilder(args).Build().Run();
        }
        private static IWebHostBuilder CreateCustomWebHostBuilder(string[] args)
        {
            var builder = new WebHostBuilder();
            builder
                .UseKestrel()
                .ConfigureServices(services => services.AddAutofac())
                .UseContentRoot(Path.Combine(Directory.GetCurrentDirectory(), "ContentRoot"))
                .UseIISIntegration()
                .UseStartup<Startup>();
            return builder;
        }
    }
}