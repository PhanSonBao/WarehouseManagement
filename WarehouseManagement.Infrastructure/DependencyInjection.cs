using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarehouseManagement.Infrastructure.Persistence;
using WarehouseManagement.Infrastructure.Repositories;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        // Repository
        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}