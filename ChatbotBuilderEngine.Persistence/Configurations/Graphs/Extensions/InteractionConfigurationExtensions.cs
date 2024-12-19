using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Interactions;
using ChatbotBuilderEngine.Persistence.Configurations.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Extensions;

internal static class InteractionConfigurationExtensions
{
    public static void ConfigureInteractionInput<T>(
        this OwnedNavigationBuilder<T, InteractionInput> builder)
        where T : class
    {
        builder.Property(i => i.Text).IsRequired(false);
        builder.Property(i => i.Option).IsRequired(false);
    }

    public static void ConfigureInteractionOutput<T>(
        this OwnedNavigationBuilder<T, InteractionOutput> builder)
        where T : class
    {
        builder.Property(o => o.TextOutput).IsRequired(false);
        builder.Property(o => o.TextExpected);
        builder.Property(o => o.OptionExpected);
        builder.Property(o => o.ExpectedOptionMetas)
            .HasConversion(new NullableDictionaryJsonConverter<OptionData, InteractionOptionMeta>())
            .HasColumnType("NVARCHAR(MAX)")
            .IsRequired(false);
    }
}