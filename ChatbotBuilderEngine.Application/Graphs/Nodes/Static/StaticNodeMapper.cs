using ChatbotBuilderEngine.Application.Graphs.Ports;
using ChatbotBuilderEngine.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderEngine.Application.Graphs.Shared.Data.Extensions;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderEngine.Application.Graphs.Nodes.Static;

[Mapper]
public static partial class StaticNodeMapper
{
    public static StaticNode<TData> ToDomain<TData>(this StaticNodeDto dto)
        where TData : Data
    {
        var nodeId = new NodeId(Guid.NewGuid());
        return StaticNode<TData>.Create(
            nodeId,
            dto.Info,
            dto.Visual,
            (TData)dto.Data,
            OutputPort<TData>.Create(
                new OutputPortId(Guid.NewGuid()),
                dto.OutputPort.Info,
                dto.OutputPort.Visual,
                nodeId));
    }

    public static StaticNodeDto ToDto<TData>(this StaticNode<TData> domain)
        where TData : Data
    {
        return new StaticNodeDto(
            domain.Info,
            domain.Visual,
            NodeType.Static,
            domain.Data.ToDataType(),
            domain.Data,
            new OutputPortDto(
                domain.OutputPort.Info,
                domain.OutputPort.Visual,
                PortDirection.Output,
                domain.Info.Identifier,
                domain.Data.ToDataType()));
    }
}