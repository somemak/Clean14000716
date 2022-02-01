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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Clean14000716.Application;
using Clean14000716.Application.Common.Mapping;
using Clean14000716.Common.Utilities;
using Clean14000716.Infrastructure;
using Clean14000716.Persistence;
using Clean14000716.WebCommon.IOC;
using Clean14000716.WebCommon.Jwt;
using Clean14000716.WebCommon.Middleware;
using FluentValidation.AspNetCore;
using StackExchange.Redis;


namespace Clean14000716.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class StartupDevelopment
    {
        private readonly SiteSettings _siteSetting;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public StartupDevelopment(IConfiguration configuration)
        {
            Configuration = configuration;
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {




            //using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            //{
            //    IDatabase db = redis.GetDatabase();

            //    var keys = redis.GetServer("localhost", 6379).Keys();

            //    string[] keysArr = keys.Select(key => (string)key).ToArray();


            //}
            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));
            services.AddControllers();
            services.AddMinimalMvc();
            services.AddPersistenceServices(Configuration);
            services.AddInfrastructureServices();
            services.AddApplicationServices(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clean14000716.Api", Version = "v1" });
                var xmlDocPath = Path.Combine(AppContext.BaseDirectory, "Clean14000716.xml");
                //show controller XML comments like summary
                c.IncludeXmlComments(xmlDocPath, true);
            });
            services.InitializeAutoMapper();
            services.AddJwtAuthentication(_siteSetting.JwtSettings);
            return services.RegisterAutofacServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCustomExceptionHandler();
            //app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean14000716.Api v1"));
            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
          
          
        }
    }
}
