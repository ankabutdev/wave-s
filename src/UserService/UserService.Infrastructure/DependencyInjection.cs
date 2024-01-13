using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using UserService.Application.Abstractions;
using UserService.Infrastructure.Persistence;

namespace UserService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        var dockerConnection = configuration.GetConnectionString("DockerConnection");
        var defaultConnection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<IAppDbContext, AppDbContext>(options =>
        {
            options.UseNpgsql(defaultConnection);
        });

        services.AddControllersWithViews()
            .AddJsonOptions(x => x.JsonSerializerOptions
            .ReferenceHandler = ReferenceHandler.IgnoreCycles);

        return services;
    }
}
