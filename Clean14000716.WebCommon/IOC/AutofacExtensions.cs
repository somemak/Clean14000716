using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Clean14000716.Application;
using Clean14000716.Application.Common.Mapping;
using Clean14000716.Common;
using Clean14000716.Common.ForAutofacMark;
using Clean14000716.Domain;
using Clean14000716.Infrastructure;
using Clean14000716.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Clean14000716.WebCommon.IOC
{
    public static class AutofacExtensions
    {
        public static void AddServices(this ContainerBuilder containerBuilder)
        {
            var commonAssembly = typeof(CommonAssemblyName).Assembly;
            var applicationAssembly = typeof(ApplicationAssemblyName).Assembly;
            var domainAssembly = typeof(DomainAssemblyName).Assembly;
            var infrastructureAssembly = typeof(InfrastructureAssemblyName).Assembly;
            var persistenceAssembly = typeof(PersistenceAssemblyName).Assembly;
            var currentAssembly = Assembly.GetExecutingAssembly();

            containerBuilder.RegisterAssemblyTypes(commonAssembly, applicationAssembly, domainAssembly,
                    infrastructureAssembly, persistenceAssembly, currentAssembly)
                .AssignableTo<IScopedDependency>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();


            containerBuilder.RegisterAssemblyTypes(commonAssembly, applicationAssembly, domainAssembly,
                    infrastructureAssembly, persistenceAssembly, currentAssembly)
                .AssignableTo<ITransientDependency>()
                .AsImplementedInterfaces()
                .InstancePerDependency();


            containerBuilder.RegisterAssemblyTypes(commonAssembly, applicationAssembly, domainAssembly,
                    infrastructureAssembly, persistenceAssembly, currentAssembly)
                .AssignableTo<ISingletonDependency>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }

        public static void AddAutoMapper(this ContainerBuilder containerBuilder)
        {
            Assembly[] assemblies = new Assembly[]
            {
            typeof(CommonAssemblyName).Assembly,
            typeof(ApplicationAssemblyName).Assembly,
            typeof(DomainAssemblyName).Assembly,
            typeof(InfrastructureAssemblyName).Assembly,
            typeof(PersistenceAssemblyName).Assembly
            };
            containerBuilder.Register(c => new MapperConfiguration(cfg =>
            {
                var allTypes = assemblies.SelectMany(a => a.ExportedTypes);

                var list = allTypes.Where(type => type.IsClass && !type.IsAbstract &&
                                                  type.GetInterfaces().Contains(typeof(IHaveMapping)))
                    .Select(type => (IHaveMapping)Activator.CreateInstance(type));

                cfg.AddProfile(new CustomMappingProfile(list));

            })).AsSelf().SingleInstance();
            containerBuilder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();
        }

        public static IServiceProvider RegisterAutofacServices(this IServiceCollection services)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            //register services
            containerBuilder.AddServices();
            //containerBuilder.AddAutoMapper();
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

    }

    //public static class AutoFacExtensions
    //{
    //    public static void RegisterAllServices(this ContainerBuilder builder)
    //    {

    //    }
    //}

}