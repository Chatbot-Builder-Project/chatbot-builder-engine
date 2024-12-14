using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Extensions;

internal static class MetaConfigurationExtensions
{
    public static void ConfigureInfoMeta<T>(
        this OwnedNavigationBuilder<T, InfoMeta> builder)
        where T : class
    {
        builder.Property(d => d.Identifier)
            .IsRequired();

        builder.Property(d => d.Name)
            .IsRequired();
    }

    public static void ConfigureVisualMeta<T>(
        this OwnedNavigationBuilder<T, VisualMeta> builder)
        where T : class
    {
        builder.Property(v => v.X)
            .IsRequired();

        builder.Property(v => v.Y)
            .IsRequired();
    }
}