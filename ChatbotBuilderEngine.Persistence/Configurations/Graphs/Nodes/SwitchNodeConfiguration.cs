﻿using ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;
using ChatbotBuilderEngine.Persistence.Configurations.Converters;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using ChatbotBuilderEngine.Persistence.Configurations.Graphs.Nodes.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Graphs.Nodes;

internal sealed class SwitchNodeConfiguration : IEntityTypeConfiguration<SwitchNode>
{
    public void Configure(EntityTypeBuilder<SwitchNode> builder)
    {
        builder.ConfigureNodeBase();

        builder.HasOne(n => n.InputPort)
            .WithOne()
            .HasForeignKey<InputPort<OptionData>>(i => i.NodeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(n => n.Enum)
            .WithMany()
            .IsRequired();

        builder.Property(n => n.Bindings)
            .HasConversion(new DictionaryJsonConverter<OptionData, FlowLinkId>())
            .HasColumnType("NVARCHAR(MAX)");

        builder.OwnsOne(n => n.SelectedOption, n => n.ConfigureOptionData());
    }
}