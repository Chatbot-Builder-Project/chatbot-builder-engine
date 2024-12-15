using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
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

        builder.HasMany(o => o.InputPorts)
            .WithMany()
            .UsingEntity<OutputInputPortJoin>(
                joinTableName,
                j => j.HasOne<InputPort<TData>>()
                    .WithMany()
                    .HasForeignKey("InputPortId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<OutputPort<TData>>()
                    .WithMany()
                    .HasForeignKey("OutputPortId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("OutputPortId", "InputPortId");
                    j.Property(jj => jj.InputPortId).ApplyEntityIdConversion();
                    j.Property(jj => jj.OutputPortId).ApplyEntityIdConversion();
                });
    }
}

internal class OutputInputPortJoin
{
    public required OutputPortId OutputPortId { get; set; }
    public required InputPortId InputPortId { get; set; }
}