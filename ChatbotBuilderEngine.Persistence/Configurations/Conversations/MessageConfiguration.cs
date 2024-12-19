using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Interactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Conversations;

internal sealed class InputMessageConfiguration : IEntityTypeConfiguration<InputMessage>
{
    public void Configure(EntityTypeBuilder<InputMessage> builder)
    {
        builder.Property<Guid>("Id").ValueGeneratedOnAdd();
        builder.HasKey("Id");

        builder.Property(i => i.CreatedAt);

        builder.HasOne(i => i.Input)
            .WithOne()
            .HasForeignKey<InteractionInput>("InputMessageId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

internal sealed class OutputMessageConfiguration : IEntityTypeConfiguration<OutputMessage>
{
    public void Configure(EntityTypeBuilder<OutputMessage> builder)
    {
        builder.Property<Guid>("Id").ValueGeneratedOnAdd();
        builder.HasKey("Id");

        builder.Property(o => o.CreatedAt);

        builder.HasOne(o => o.Output)
            .WithOne()
            .HasForeignKey<InteractionOutput>("OutputMessageId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}