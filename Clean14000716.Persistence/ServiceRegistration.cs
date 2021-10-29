using System;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.EFCore;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.OtherORM.Dapper;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.OtherORM.Dapper.IRepositories;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.OtherORM.Dapper.IRepositories.Base;
using Clean14000716.Persistence.EFCore.Context.SqlServer;
using Clean14000716.Persistence.OtherORM.Dapper.Repositories;
using Clean14000716.Persistence.OtherORM.Dapper.Repositories.Base;
using Clean14000716.Persistence.OtherORM.Dapper.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Clean14000716.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDatabaseContext, ApplicationContext>();

            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(ICrudRepository<,>), typeof(CrudRepository<,>));

            var connectionStringKey = configuration.GetConnectionString("InUseKey");
            var connectionString = configuration.GetConnectionString(connectionStringKey);


            switch (connectionStringKey)
            {
                case "SqlConnection":
                    services.AddDbContext<ApplicationContext>(options =>
                    {
                        options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
                        options.UseSqlServer(connectionString, dbOptions =>
                        {
                            var minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                            dbOptions.CommandTimeout(minutes);
                            dbOptions.EnableRetryOnFailure();
                        });
                    });
                    break;

                case "SqliteConnection":
                    //services.AddDbContext<SqlLiteContext>(options =>
                    //{
                    //    options.UseSqlite(connectionString, dbOptions =>
                    //    {
                    //        var minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                    //        dbOptions.CommandTimeout(minutes);
                    //    });
                    //});
                    break;
            }
        }
    }
}