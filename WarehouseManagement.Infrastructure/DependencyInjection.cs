using System.Reflection;
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
        services.AddScoped<IUnitOfWork, AppDbContext>();

        // Repository
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }

    // public static IServiceCollection AddCustomMapper(this IServiceCollection services)
    // {
    //     var config = new MapperConfiguration();
    //
    //     var profiles = Assembly.GetExecutingAssembly()
    //         .GetTypes()
    //         .Where(t => typeof(IMappingProfile).IsAssignableFrom(t) && !t.IsInterface);
    //
    //     services.AddSingleton(profiles);
    //     return services;
    // }
}