using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean14000716.Application;
using Clean14000716.Application.Common.Mapping;
using Clean14000716.Infrastructure;
using Clean14000716.Persistence;
using Clean14000716.WebCommon.IOC;
using Clean14000716.WebCommon.Middleware;
using FluentValidation.AspNetCore;
using StackExchange.Redis;


namespace Clean14000716.Api
{
    public class StartupDevelopment
    {
        public StartupDevelopment(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            //{
            //    IDatabase db = redis.GetDatabase();

            //    var keys = redis.GetServer("localhost", 6379).Keys();

            //    string[] keysArr = keys.Select(key => (string)key).ToArray();

                 
            //}

            services.AddControllers();
            services.AddMinimalMvc();
            services.AddPersistenceServices(Configuration);
            services.AddInfrastructureServices();
            services.AddApplicationServices(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clean14000716.Api", Version = "v1" });
            });
            services.InitializeAutoMapper();
            return services.RegisterAutofacServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCustomExceptionHandler();
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean14000716.Api v1"));
            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
