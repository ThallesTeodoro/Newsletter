using Microsoft.Extensions.DependencyInjection;
using Newsletter.Domain.Contracts.Persistence;
using Newsletter.Infrastructure.Persistence;

namespace Newsletter.Infrastructure;

public static class DepencencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<ISubscriberRepository, SubscriberRepository>();

        return services;
    }
}
