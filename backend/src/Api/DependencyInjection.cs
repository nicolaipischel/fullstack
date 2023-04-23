using Api.Definitions;
using Api.Implementations;

namespace Api;

internal static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<RepositoryOptions>(config.GetSection(RepositoryOptions.SectionName));
        services.AddScoped(typeof(IRepository<,>), typeof(JsonRepository<,>));

        return services;
    }
}