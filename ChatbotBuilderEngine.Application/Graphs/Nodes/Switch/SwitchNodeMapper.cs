using ChatbotBuilderEngine.Application.Graphs.Ports;
using ChatbotBuilderEngine.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderEngine.Application.Graphs.Shared.Data;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using Riok.Mapperly.Abstractions;
using Enum = ChatbotBuilderEngine.Domain.Graphs.Entities.Enum;

namespace ChatbotBuilderEngine.Application.Graphs.Nodes.Switch;

[Mapper]
public static partial class SwitchNodeMapper
{
    public static SwitchNode ToDomain(
        this SwitchNodeDto dto,
        Enum @enum,
        IReadOnlyDictionary<OptionData, FlowLinkId> bindings)
    {
        var nodeId = new NodeId(Guid.NewGuid());
        return SwitchNode.Create(
            nodeId,
            dto.Info,
            dto.Visual,
            InputPort<OptionData>.Create(
                new InputPortId(Guid.NewGuid()),
                dto.InputPort.Info,
                dto.InputPort.Visual,
                nodeId),
            @enum,
            bindings);
    }

    public static SwitchNodeDto ToDto(
        this SwitchNode domain,
        IReadOnlyDictionary<OptionData, int> bindings)
    {
        return new SwitchNodeDto(
            domain.Info,
            domain.Visual,
            NodeType.Switch,
            new InputPortDto(
                domain.InputPort.Info,
                domain.InputPort.Visual,
                PortDirection.Input,
                domain.Info.Identifier,
                DataType.Option),
            domain.Enum.Info.Identifier,
            bindings);
    }
}