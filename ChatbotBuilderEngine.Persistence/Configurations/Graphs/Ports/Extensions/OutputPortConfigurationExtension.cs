using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Ports.Extensions;

internal static class OutputPortConfigurationExtension
{
    public static void ConfigureOutputPort<TData>(
        this EntityTypeBuilder<OutputPort<TData>> builder,
        string joinTableName)
        where TData : Data
    {
        builder.ConfigurePortBase<OutputPort<TData>, OutputPortId>();

        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).ApplyEntityIdConversion();
        builder.Property(o => o.NodeId).ApplyEntityIdConversion();

        builder.HasMany(o => o.InputPorts)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                joinTableName,
                j => j.HasOne<InputPort<TData>>()
                    .WithMany()
                    .HasForeignKey("InputPortId"),
                j => j.HasOne<OutputPort<TData>>()
                    .WithMany()
                    .HasForeignKey("OutputPortId"),
                j => j.HasKey("OutputPortId", "InputPortId"));
    }
}