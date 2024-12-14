using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Enum = ChatbotBuilderEngine.Domain.Graphs.Entities.Enum;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs;

internal sealed class EnumConfiguration : IEntityTypeConfiguration<Enum>
{
    public void Configure(EntityTypeBuilder<Enum> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ApplyEntityIdConversion();

        builder.OwnsOne(e => e.Info, i => i.ConfigureInfoMeta());
        builder.OwnsMany(e => e.Options)
            .WithOwner()
            .HasForeignKey(o => o.EnumId);
    }
}