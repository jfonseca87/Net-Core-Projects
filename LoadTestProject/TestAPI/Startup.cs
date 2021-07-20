using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestAPI.Models;
using TestAPI.Repository.Implementations;
using TestAPI.Repository.Interfaces;
using TestAPI.Services.Implementations;
using TestAPI.Services.Interfaces;

namespace TestAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<TestdbContext>(options => options.UseSqlServer(Configuration["TestConnection"]));

            services.AddTransient<ITableOneRepository, TableOneRepository>();
            services.AddTransient<ITableTwoRepository, TableTwoRepository>();
            
            services.AddTransient<ITableOneBusiness, TableOneBusiness>();
            services.AddTransient<ITableTwoBusiness, TableTwoBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
