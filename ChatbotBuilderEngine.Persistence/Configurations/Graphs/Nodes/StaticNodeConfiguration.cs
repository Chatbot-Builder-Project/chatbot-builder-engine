using ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Nodes.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Nodes;

internal class TextStaticNodeConfiguration : IEntityTypeConfiguration<StaticNode<TextData>>
{
    public void Configure(EntityTypeBuilder<StaticNode<TextData>> builder)
    {
        builder.ConfigureStaticNode(d => d.ConfigureTextData());
    }
}

internal class OptionStaticNodeConfiguration : IEntityTypeConfiguration<StaticNode<OptionData>>
{
    public void Configure(EntityTypeBuilder<StaticNode<OptionData>> builder)
    {
        builder.ConfigureStaticNode(d => d.ConfigureOptionData());
    }
}

internal class ImageStaticNodeConfiguration : IEntityTypeConfiguration<StaticNode<ImageData>>
{
    public void Configure(EntityTypeBuilder<StaticNode<ImageData>> builder)
    {
        builder.ConfigureStaticNode(d => d.ConfigureImageData());
    }
}