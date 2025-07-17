using Assignment.Application.Common.Interface.Persistence;
using Assignment.Application.Common.Interface.Services;
using Assignment.Infrastructure.DataAccess;
using Assignment.Infrastructure.Repository;
using Assignment.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection service)
        { 
            service.AddTransient<ISqlDataAccess, SqlDataAccess>();
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            #region Repository


            #endregion
            return service;
        }
    }
}
