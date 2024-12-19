using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Ports.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Ports;

internal sealed class OutputPortConfiguration : IEntityTypeConfiguration<Port<OutputPortId>>
{
    public void Configure(EntityTypeBuilder<Port<OutputPortId>> builder)
    {
        builder.UseTpcMappingStrategy();

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ApplyEntityIdConversion();
    }
}

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