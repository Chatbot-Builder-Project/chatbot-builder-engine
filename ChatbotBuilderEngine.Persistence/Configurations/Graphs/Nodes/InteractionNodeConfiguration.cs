using ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Interactions;
using ChatbotBuilderEngine.Persistence.Configurations.Converters;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Extensions;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Nodes.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Nodes;

internal sealed class InteractionNodeConfiguration : IEntityTypeConfiguration<InteractionNode>
{
    public void Configure(EntityTypeBuilder<InteractionNode> builder)
    {
        builder.ConfigureNodeBase();

        builder.HasOne(n => n.TextInputPort)
            .WithOne()
            .HasForeignKey<InputPort<TextData>>(p => p.NodeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(n => n.TextOutputPort)
            .WithOne()
            .HasForeignKey<OutputPort<TextData>>(p => p.NodeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(n => n.OutputEnum)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(n => n.OptionOutputPort)
            .WithOne()
            .HasForeignKey<OutputPort<OptionData>>(p => p.NodeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(n => n.OutputOptionMetas)
            .HasConversion(new NullableDictionaryJsonConverter<OptionData, InteractionOptionMeta>())
            .HasColumnType("NVARCHAR(MAX)")
            .IsRequired(false);

        // Nested owned entity with Nullability cause issues
        // Hence we are using HasOne with WithOne instead of OwnsOne
        builder.HasOne(n => n.InteractionInput)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey<InteractionInput>("InteractionNodeId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction); // Issue
    }
}