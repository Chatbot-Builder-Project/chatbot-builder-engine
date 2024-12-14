using ChatbotBuilderEngine.Domain.Graphs.Entities.Links;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Links.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Links;

internal sealed class DataLinkConfiguration : IEntityTypeConfiguration<DataLink>
{
    public void Configure(EntityTypeBuilder<DataLink> builder)
    {
        builder.ConfigureLinkBase<DataLink, DataLinkId>();

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).ApplyEntityIdConversion();

        builder.Property(l => l.InputPortId).ApplyEntityIdConversion();
        builder.Property(l => l.OutputPortId).ApplyEntityIdConversion();
    }
}