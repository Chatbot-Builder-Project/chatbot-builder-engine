using ChatbotBuilderEngine.Domain.Graphs;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs;

internal sealed class GraphConfiguration : IEntityTypeConfiguration<Graph>
{
    public void Configure(EntityTypeBuilder<Graph> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ApplyEntityIdConversion();

        builder.Property(g => g.StartNodeId).ApplyEntityIdConversion();
        builder.HasOne<Node>()
            .WithOne()
            .HasForeignKey<Graph>(g => g.StartNodeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(g => g.Enums)
            .WithOne()
            .HasForeignKey("GraphId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.InputPorts)
            .WithOne()
            .HasForeignKey("GraphId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.OutputPorts)
            .WithOne()
            .HasForeignKey("GraphId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.Nodes)
            .WithOne()
            .HasForeignKey("GraphId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.FlowLinks)
            .WithOne()
            .HasForeignKey("GraphId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.DataLinks)
            .WithOne()
            .HasForeignKey("GraphId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}