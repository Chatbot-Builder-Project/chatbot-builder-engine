using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Persistence.Configurations.Converters;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Extensions;

internal static class ConversionExtensions
{
    public static void ApplyEntityIdConversion<TId>(
        this PropertyBuilder<TId> propertyBuilder)
        where TId : EntityId<TId>
    {
        propertyBuilder.HasConversion(new EntityIdGuidConverter<TId>());
    }
}