using ChatbotBuilderEngine.Domain.Core.Abstract;
using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Persistence.Configurations.Converters;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Extensions;

internal static class CommonExtensions
{
    public static void ApplyEntityIdConversion<TId>(
        this PropertyBuilder<TId> propertyBuilder)
        where TId : EntityId<TId>
    {
        propertyBuilder.HasConversion(new EntityIdGuidConverter<TId>());
    }

    public static void ConfigureAggregateRoot<T>(
        this EntityTypeBuilder<T> builder)
        where T : class, IAggregateRoot
    {
        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();
    }
}