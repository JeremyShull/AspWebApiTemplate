using BufTools.DataStorage.EntityFramework;
using BufTools.DataStorage;
using BufTools.DI.ReflectionHelpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Template.Infrastructure
{
    /// <summary>
    /// Class to register Infrastructure related services
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Adds infrastructure related dependencies to the service collection
        /// </summary>
        /// <param name="services">The service collection to add to</param>
        /// <param name="connectionString">The connection string to the database</param>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddSingletonClasses<IDataContext>(typeof(ServiceRegistration).Assembly);
            services.AddScopedUnitOfWork<DataContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
