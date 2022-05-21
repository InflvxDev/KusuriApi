using MediatR;
using Kusuri.Employees.Domain;
using Kusuri.Employees.Infrastructure.Persistence;
using Kusuri.Shared.Domain.Respository.Mongo;
using Kusuri.Shared.Helpers;

namespace Employees.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDBSettings>(configuration.GetSection("MongoDbSettings"));
        services.AddScoped<IEmployeeRepository, MongoDBEmployeeRepository>();

        services.AddMediatR(typeof(Program));
        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Employees));

        return services;
    }
}
