using ChatbotBuilderEngine.Application.Core.Abstract.Repositories;
using ChatbotBuilderEngine.Persistence;
using ChatbotBuilderEngine.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChatbotBuilderEngine.DependencyInjection;

public static class PersistenceServicesExtension
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            options.UseSqlServer(configuration.GetConnectionString("AppDbContextConnection") ??
                                 throw new ArgumentException("AppDbContextConnection not found"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(ICudRepository<>), typeof(CudRepository<>));
    }
}