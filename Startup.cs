﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ConfigTemplate.ContentRoot.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConfigTemplate
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private  IContainer _container;
        public Startup(IHostingEnvironment env)
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddYamlFile("appsettings.yml", optional: false, reloadOnChange: true)
                .AddYamlFile($"appsettings.{env.EnvironmentName}.yml", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            ConfigureSettings(services);
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ApiIoC>();
            containerBuilder.Populate(services);
            _container = containerBuilder.Build();
            return new AutofacServiceProvider(_container);
        }

        private void ConfigureSettings(IServiceCollection services)
        {
            services.Configure<TestSettings>(_config.GetSection("Test"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}