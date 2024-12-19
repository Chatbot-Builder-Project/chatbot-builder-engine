using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Extensions;

internal static class DataConfigurationExtensions
{
    public static void ConfigureTextData<T>(
        this OwnedNavigationBuilder<T, TextData> builder)
        where T : class
    {
        builder.Property(d => d.Text)
            .IsRequired();
    }

    public static void ConfigureOptionData<T>(
        this OwnedNavigationBuilder<T, OptionData> builder)
        where T : class
    {
        builder.Property(d => d.EnumId)
            .IsRequired()
            .ApplyEntityIdConversion();

        builder.Property(d => d.Value)
            .IsRequired();
    }

    public static void ConfigureImageData<T>(
        this OwnedNavigationBuilder<T, ImageData> builder)
        where T : class
    {
        builder.Property(d => d.Url)
            .IsRequired();
    }
}