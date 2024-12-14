using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Nodes.Extensions;

internal static class NodeConfigurationExtension
{
    public static void ConfigureNodeBase<TNode>(
        this EntityTypeBuilder<TNode> builder)
        where TNode : Node
    {
        builder.OwnsOne(n => n.Info, i => i.ConfigureInfoMeta());
        builder.OwnsOne(n => n.Visual, v => v.ConfigureVisualMeta());
    }
}