using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Links.Extensions;

internal static class LinkConfigurationExtension
{
    public static void ConfigureLinkBase<TLink, TId>(this EntityTypeBuilder<TLink> builder)
        where TLink : Link<TId>
        where TId : EntityId<TId>
    {
        builder.OwnsOne(p => p.Info, i => i.ConfigureInfoMeta());
        builder.OwnsOne(p => p.Visual, v => v.ConfigureVisualMeta());
    }
}