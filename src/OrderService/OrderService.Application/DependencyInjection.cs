using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Mappers;
using System.Reflection;

namespace OrderService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(typeof(MappingConfiguration));
        return services;
    }
}
