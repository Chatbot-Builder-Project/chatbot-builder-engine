using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Ports.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Ports;

internal sealed class TextInputPortConfiguration : IEntityTypeConfiguration<InputPort<TextData>>
{
    public void Configure(EntityTypeBuilder<InputPort<TextData>> builder)
    {
        builder.ConfigureInputPort(d => d.ConfigureTextData());
    }
}

internal sealed class OptionInputPortConfiguration : IEntityTypeConfiguration<InputPort<OptionData>>
{
    public void Configure(EntityTypeBuilder<InputPort<OptionData>> builder)
    {
        builder.ConfigureInputPort(d => d.ConfigureOptionData());
    }
}

internal sealed class ImageInputPortConfiguration : IEntityTypeConfiguration<InputPort<ImageData>>
{
    public void Configure(EntityTypeBuilder<InputPort<ImageData>> builder)
    {
        builder.ConfigureInputPort(d => d.ConfigureImageData());
    }
}