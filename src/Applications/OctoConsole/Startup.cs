﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OctoPatch.Server;

namespace OctoConsole
{
    internal sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSignalR();

            var repository = new Repository();
            var runtime = new Runtime(repository);

            services.AddSingleton<IRepository>(repository);
            services.AddSingleton<IRuntime>(runtime);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
 
            app.UseCors(options => 
                options.AllowAnyHeader().AllowCredentials()
                    .WithOrigins("https://ausliebezumcode.github.io"));

            app.UseRouting();
            app.UseStaticFiles();
        
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<RuntimeHub>("/runtimeHub");
            });
        }
    }
}
