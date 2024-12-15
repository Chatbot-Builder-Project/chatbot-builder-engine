using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Ports.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Ports;

internal sealed class InputPortConfiguration : IEntityTypeConfiguration<Port<InputPortId>>
{
    public void Configure(EntityTypeBuilder<Port<InputPortId>> builder)
    {
        builder.UseTpcMappingStrategy();

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ApplyEntityIdConversion();
    }
}

internal sealed class TextInputPortConfiguration : IEntityTypeConfiguration<InputPort<TextData>>
{
    public void Configure(EntityTypeBuilder<InputPort<TextData>> builder)
    {
        builder.ConfigurePortBase<InputPort<TextData>, InputPortId>();
        builder.OwnsOne(p => p.Data, d => d.ConfigureTextData());
    }
}

internal sealed class OptionInputPortConfiguration : IEntityTypeConfiguration<InputPort<OptionData>>
{
    public void Configure(EntityTypeBuilder<InputPort<OptionData>> builder)
    {
        builder.ConfigurePortBase<InputPort<OptionData>, InputPortId>();
        builder.OwnsOne(p => p.Data, d => d.ConfigureOptionData());
    }
}

internal sealed class ImageInputPortConfiguration : IEntityTypeConfiguration<InputPort<ImageData>>
{
    public void Configure(EntityTypeBuilder<InputPort<ImageData>> builder)
    {
        builder.ConfigurePortBase<InputPort<ImageData>, InputPortId>();
        builder.OwnsOne(p => p.Data, d => d.ConfigureImageData());
    }
}