using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RentAndInvoice.Core.Application.Behaviors;

namespace RentAndInvoice.Core.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
        });

        services.AddScoped(typeof(IPipelineBehavior<,>),typeof(LoggingPipelineBehavior<,>));

        return services;
    }
}
