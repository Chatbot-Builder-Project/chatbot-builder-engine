using ChatbotBuilderEngine.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChatbotBuilderEngine.WebApplicationExtensions;

public static class DatabaseWebApplicationExtensions
{
    public static async Task MigrateAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync();
    }
}