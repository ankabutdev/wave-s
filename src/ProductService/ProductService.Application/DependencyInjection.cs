﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Mappers;
using System.Reflection;

namespace ProductService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(typeof(MappingConfiguration));
        return services;
    }
}
