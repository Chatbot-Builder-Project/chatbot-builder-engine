﻿using ChatbotBuilderEngine.Domain.Core.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ChatbotBuilderEngine.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
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

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetTimestamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity.GetType().IsAssignableTo(typeof(IAggregateRoot))
                        && e.State is EntityState.Added or EntityState.Modified);

        foreach (var entry in entries)
        {
            var now = DateTime.UtcNow;
            entry.Property(nameof(IAggregateRoot.UpdatedAt)).CurrentValue = now;

            if (entry.State == EntityState.Added)
            {
                entry.Property(nameof(IAggregateRoot.CreatedAt)).CurrentValue = now;
            }
        }
    }
}