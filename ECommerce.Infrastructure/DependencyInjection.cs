using ECommerce.Application.Abstractions.Persistence;
using ECommerce.Infrastructure.Persistence;
using ECommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? "Server=(localdb)\\mssqllocaldb;Database=ECommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        var provider = configuration["Database:Provider"]?.ToLowerInvariant() ?? "sqlserver";

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            _ = provider switch
            {
                "sqlserver" => options.UseSqlServer(connectionString),
                _ => throw new InvalidOperationException($"Unsupported database provider '{provider}'.")
            };
        });

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
