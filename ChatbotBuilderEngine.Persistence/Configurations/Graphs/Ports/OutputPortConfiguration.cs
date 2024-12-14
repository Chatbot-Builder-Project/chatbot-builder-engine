using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Ports.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Ports;

internal sealed class TextOutputPortConfiguration : IEntityTypeConfiguration<OutputPort<TextData>>
{
    public void Configure(EntityTypeBuilder<OutputPort<TextData>> builder)
    {
        builder.ConfigureOutputPort("TextOutputPortInputPort");
    }
}

internal sealed class OptionOutputPortConfiguration : IEntityTypeConfiguration<OutputPort<OptionData>>
{
    public void Configure(EntityTypeBuilder<OutputPort<OptionData>> builder)
    {
        builder.ConfigureOutputPort("OptionOutputPortInputPort");
    }
}

internal sealed class ImageOutputPortConfiguration : IEntityTypeConfiguration<OutputPort<ImageData>>
{
    public void Configure(EntityTypeBuilder<OutputPort<ImageData>> builder)
    {
        builder.ConfigureOutputPort("ImageOutputPortInputPort");
    }
}