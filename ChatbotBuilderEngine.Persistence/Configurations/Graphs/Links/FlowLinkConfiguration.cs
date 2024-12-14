using ChatbotBuilderEngine.Domain.Graphs.Entities.Links;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Links.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Links;

internal sealed class FlowLinkConfiguration : IEntityTypeConfiguration<FlowLink>
{
    public void Configure(EntityTypeBuilder<FlowLink> builder)
    {
        builder.ConfigureLinkBase<FlowLink, FlowLinkId>();

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).ApplyEntityIdConversion();

        builder.Property(l => l.InputNodeId).ApplyEntityIdConversion();
        builder.Property(l => l.OutputNodeId).ApplyEntityIdConversion();
    }
}