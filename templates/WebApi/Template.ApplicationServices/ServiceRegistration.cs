using BufTools.DI.ReflectionHelpers;
using Microsoft.Extensions.DependencyInjection;
using Template.ApplicationServices.Constants;

namespace Template.ApplicationServices
{
    /// <summary>
    /// Class to register ApplicationServices related services
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Adds application services related dependencies to the service collection
        /// </summary>
        /// <param name="services">The service collection to add to</param>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScopedClassesWithAttribute<CommandAttribute>(typeof(ServiceRegistration).Assembly);

            return services;
        }
    }
}
