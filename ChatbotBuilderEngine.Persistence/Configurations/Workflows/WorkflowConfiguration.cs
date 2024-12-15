using ChatbotBuilderEngine.Domain.Graphs;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Workflows;

internal sealed class WorkflowConfiguration : IEntityTypeConfiguration<Workflow>
{
    public void Configure(EntityTypeBuilder<Workflow> builder)
    {
        builder.ConfigureAggregateRoot();

        builder.HasKey(w => w.Id);
        builder.Property(w => w.Id).ApplyEntityIdConversion();

        builder.Property(w => w.Name).IsRequired();
        builder.Property(w => w.Description).IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(w => w.OwnerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<Graph>()
            .WithMany()
            .HasForeignKey(w => w.GraphId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}