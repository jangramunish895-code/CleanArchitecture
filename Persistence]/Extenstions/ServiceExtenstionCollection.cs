using Application.Interfaces.Respositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence_.DataContexts;
using Persistence_.Extenstions.Repositories;

namespace Persistence_.Extenstions;

public static class ServiceExtenstionCollection
{
    public static void AddPersitenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddRepositories();
    }

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}