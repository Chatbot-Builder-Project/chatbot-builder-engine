﻿using ChatbotBuilderEngine.Persistence;
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
    }
}