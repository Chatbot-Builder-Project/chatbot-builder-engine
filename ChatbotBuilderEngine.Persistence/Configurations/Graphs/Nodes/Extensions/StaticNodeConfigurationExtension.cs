using ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Nodes.Extensions;

internal static class StaticNodeConfigurationExtension
{
    public static void ConfigureStaticNode<TData>(
        this EntityTypeBuilder<StaticNode<TData>> builder,
        Action<OwnedNavigationBuilder<StaticNode<TData>, TData>> configureData)
        where TData : Data
    {
        builder.ConfigureNodeBase();

        builder.OwnsOne(n => n.Data, configureData);

        builder.HasOne(n => n.OutputPort)
            .WithOne()
            .HasForeignKey<OutputPort<TData>>(o => o.NodeId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}