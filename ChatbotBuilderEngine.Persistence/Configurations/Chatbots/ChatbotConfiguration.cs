using ChatbotBuilderEngine.Domain.Chatbots;
using ChatbotBuilderEngine.Domain.Graphs;
using ChatbotBuilderEngine.Domain.Workflows;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Chatbots;

internal sealed class ChatbotConfiguration : IEntityTypeConfiguration<Chatbot>
{
    public void Configure(EntityTypeBuilder<Chatbot> builder)
    {
        builder.ConfigureAggregateRoot();

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ApplyEntityIdConversion();

        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.Description).IsRequired();

        builder.HasOne<Workflow>()
            .WithMany()
            .HasForeignKey(c => c.WorkflowId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.OwnsOne(c => c.Version, config =>
        {
            config.Property(v => v.Major).IsRequired();
            config.HasIndex(v => v.Major).IsUnique();
        });

        builder.HasOne(c => c.Graph)
            .WithOne()
            .HasForeignKey<Graph>("ChatbotId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(c => c.IsPublic).IsRequired();
    }
}