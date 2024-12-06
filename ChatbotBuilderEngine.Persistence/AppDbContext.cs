using ChatbotBuilderEngine.Domain.Core.Primitives;
using Microsoft.EntityFrameworkCore;

namespace ChatbotBuilderEngine.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }

    public override int SaveChanges()
    {
        SetTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetTimestamps()
    {
        var entries = ChangeTracker.Entries().Where(e =>
            e is { Entity: Entity, State: EntityState.Added or EntityState.Modified });
        foreach (var entry in entries)
        {
            var now = DateTime.UtcNow;
            ((Entity)entry.Entity).UpdatedAt = now;

            if (entry.State == EntityState.Added)
            {
                ((Entity)entry.Entity).CreatedAt = now;
            }
        }
    }
}