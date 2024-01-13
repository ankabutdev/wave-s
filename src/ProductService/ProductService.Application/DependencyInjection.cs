using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Interfaces.Files;
using ProductService.Application.Mappers;
using ProductService.Application.Services.Files;
using System.Reflection;

namespace ProductService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(typeof(MappingConfiguration));
        services.AddScoped<IFileService, FileService>();
        return services;
    }
}
