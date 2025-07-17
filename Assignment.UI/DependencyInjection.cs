using Assignment.UI.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Assignment.UI
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMappings();
            return services;
        }
    }

}
