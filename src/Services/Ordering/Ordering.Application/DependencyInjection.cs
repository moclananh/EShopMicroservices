using BuidingBlocks.Behaviors;
using BuildingBlocks.Messaging.Masstransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using System.Reflection;

namespace Ordering.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
                cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            //add feature flag management
            services.AddFeatureManagement();
            //add MessageBroker
            services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
