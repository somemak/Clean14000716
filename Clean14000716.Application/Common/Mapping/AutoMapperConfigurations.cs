using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean14000716.Application.Common.Mapping
{
    public static class AutoMapperConfigurations
    {

        public static void InitializeAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddMappingProfile();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddMappingProfile(this IMapperConfigurationExpression config)
        {
            config.AddMappingProfile(Assembly.GetExecutingAssembly());
        }
        public static void AddMappingProfile(this IMapperConfigurationExpression config,params Assembly[] assemblies)
        {
            var allTypes = assemblies.SelectMany(a => a.ExportedTypes);

            var list = allTypes.Where(type => type.IsClass && !type.IsAbstract &&
                                              type.GetInterfaces().Contains(typeof(IHaveMapping)))
                .Select(type => (IHaveMapping)Activator.CreateInstance(type));

            var profile = new CustomMappingProfile(list);

            config.AddProfile(profile);
        }

    }
}