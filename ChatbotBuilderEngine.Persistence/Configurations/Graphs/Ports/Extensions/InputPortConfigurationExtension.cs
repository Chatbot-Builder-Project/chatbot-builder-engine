using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Ports.Extensions;

internal static class InputPortConfigurationExtension
{
    public static void ConfigureInputPort<TData>(
        this EntityTypeBuilder<InputPort<TData>> builder,
        Action<OwnedNavigationBuilder<InputPort<TData>, TData>> configureData)
        where TData : Data
    {
        builder.ConfigurePortBase<InputPort<TData>, InputPortId>();

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ApplyEntityIdConversion();

        builder.Property(i => i.NodeId).ApplyEntityIdConversion();

        builder.OwnsOne(i => i.Data, configureData);
    }
}