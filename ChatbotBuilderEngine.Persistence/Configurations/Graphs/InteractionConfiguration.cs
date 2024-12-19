using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Interactions;
using ChatbotBuilderEngine.Persistence.Configurations.Converters;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs;

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

internal sealed class InteractionOutputConfiguration : IEntityTypeConfiguration<InteractionOutput>
{
    public void Configure(EntityTypeBuilder<InteractionOutput> builder)
    {
        builder.Property<Guid>("Id").ValueGeneratedOnAdd();
        builder.HasKey("Id");

        builder.OwnsOne(o => o.TextOutput, t => t.ConfigureTextData());

        builder.Property(o => o.TextExpected);
        builder.Property(o => o.OptionExpected);

        builder.Property(o => o.ExpectedOptionMetas)
            .HasConversion(new NullableDictionaryJsonConverter<OptionData, InteractionOptionMeta>())
            .HasColumnType("NVARCHAR(MAX)")
            .IsRequired(false);
    }
}