﻿using Mapster;
using MapsterMapper;
using System.Reflection;

namespace Assignment.UI.Mapping
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddSingleton<IMapper, ServiceMapper>();
            return services;
        }
    }
}
