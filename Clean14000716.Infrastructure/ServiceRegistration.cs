using System;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.EFCore;
using Clean14000716.Application.Common.Interfaces.Public;
using Clean14000716.Infrastructure.Public;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack.Redis;

namespace Clean14000716.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IRedisClientsManager), 
                new RedisManagerPool("redis://localhost:6379?ssl=true&db=0"));

           
        }
    }
}