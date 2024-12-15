using ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes.Interaction;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;
using ChatbotBuilderEngine.Persistence.Configurations.Converters;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
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
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(n => n.TextOutputPort)
            .WithOne()
            .HasForeignKey<OutputPort<TextData>>(p => p.NodeId)
            .OnDelete(DeleteBehavior.NoAction); // Issue

        builder.HasOne(n => n.OutputEnum)
            .WithMany();

        builder.HasOne(n => n.OptionOutputPort)
            .WithOne()
            .HasForeignKey<OutputPort<OptionData>>(p => p.NodeId)
            .OnDelete(DeleteBehavior.Cascade);

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
            .OnDelete(DeleteBehavior.Cascade);
    }
}

internal sealed class InteractionInputConfiguration : IEntityTypeConfiguration<InteractionInput>
{
    public void Configure(EntityTypeBuilder<InteractionInput> builder)
    {
        builder.Property<Guid>("Id").ValueGeneratedOnAdd();
        builder.HasKey("Id");

        builder.OwnsOne(i => i.Text, t => t.ConfigureTextData());
        builder.OwnsOne(i => i.Option, o => o.ConfigureOptionData());
    }
}