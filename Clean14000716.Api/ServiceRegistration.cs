using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Clean14000716.Application;
using Clean14000716.Domain.Entities.Identity;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Clean14000716.Api
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddMinimalMvc(this IServiceCollection services)
        {
            //https://github.com/aspnet/Mvc/blob/release/2.2/src/Microsoft.AspNetCore.Mvc/MvcServiceCollectionExtensions.cs
            services.AddMvcCore(options =>
                {
                    // اعمال احراز هویت به همه کنترلر ها
                    options.Filters.Add(new AuthorizeFilter());

                    //Like [ValidateAntiforgeryToken] attribute but dose not validatie for GET and HEAD http method
                    //You can ingore validate by using [IgnoreAntiforgeryToken] attribute
                    //Use this filter when use cookie 
                    //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

                    //options.UseYeKeModelBinder();
                })
                //.AddApiExplorer()
                //.AddAuthorization()
                .AddFormatterMappings()
                .AddDataAnnotations()
                .AddFluentValidation(cfg =>
                    cfg.RegisterValidatorsFromAssemblyContaining<ApplicationAssemblyName>())
            //    .AddJsonFormatters(/*options =>
            //{
            //    options.Formatting = Newtonsoft.Json.Formatting.Indented;
            //    options.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            //}*/)
                .AddCors()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
 
      

    }
}