using ChatbotBuilderEngine.Application.Graphs.Enums;
using ChatbotBuilderEngine.Application.Graphs.Links.DataLinks;
using ChatbotBuilderEngine.Application.Graphs.Links.FlowLinks;
using ChatbotBuilderEngine.Application.Graphs.Nodes;
using ChatbotBuilderEngine.Application.Graphs.Nodes.Interaction;
using ChatbotBuilderEngine.Application.Graphs.Nodes.Prompt;
using ChatbotBuilderEngine.Application.Graphs.Nodes.Static;
using ChatbotBuilderEngine.Application.Graphs.Nodes.Switch;
using ChatbotBuilderEngine.Domain.Graphs;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Links;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes.Prompt;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderEngine.Application.Graphs;

[Mapper]
public static partial class GraphMapper
{
    public static Graph ToDomain(this GraphDto dto)
    {
        var enums = dto.Enums
            .Select(e => e.ToDomain())
            .ToList();

        var enumByIdentifier = enums.ToDictionary(e => e.Info.Identifier);

        var flowLinkIdByIdentifier = dto.FlowLinks.ToDictionary(
            fl => fl.Info.Identifier,
            _ => new FlowLinkId(Guid.NewGuid()));

        var nodes = dto.Nodes
            .Select(node =>
            {
                switch (node)
                {
                    case InteractionNodeDto interactionNode:
                        return interactionNode.ToDomain(enumByIdentifier[node.Info.Identifier]);

                    case StaticNodeDto staticNode:
                    {
                        var dataType = staticNode.Data.GetType();
                        var toDomainMethod = typeof(StaticNodeMapper).GetMethod(nameof(ToDomain))
                                             ?? throw new InvalidOperationException("ToDomain method not found.");
                        var genericMethod = toDomainMethod.MakeGenericMethod(dataType);
                        return (Node)genericMethod.Invoke(null, [dto])!;
                    }

                    case PromptNodeDto promptNode:
                        return promptNode.ToDomain();

                    case SwitchNodeDto switchNode:
                        return switchNode.ToDomain(
                            enumByIdentifier[node.Info.Identifier],
                            switchNode.Bindings.ToDictionary(
                                b => b.Key,
                                b => flowLinkIdByIdentifier[b.Value]));

                    default:
                        throw new ArgumentOutOfRangeException(nameof(node));
                }
            })
            .ToList();

        var inputPorts = new List<Port<InputPortId>>();
        var outputPorts = new List<Port<OutputPortId>>();

        foreach (var node in nodes)
        {
            if (node is IInputNode inputNode)
            {
                inputPorts.AddRange(inputNode.GetInputPorts());
            }

            if (node is IOutputNode outputNode)
            {
                outputPorts.AddRange(outputNode.GetOutputPorts());
            }
        }

        var inputPortIdentifierById = inputPorts.ToDictionary(
            ip => ip.Info.Identifier,
            ip => ip.Id);

        var outputPortIdentifierById = outputPorts.ToDictionary(
            op => op.Info.Identifier,
            op => op.Id);

        var dataLinks = dto.DataLinks
            .Select(dl => DataLink.Create(
                new DataLinkId(Guid.NewGuid()),
                dl.Info,
                dl.Visual,
                inputPortIdentifierById[dl.InputPortIdentifier],
                outputPortIdentifierById[dl.OutputPortIdentifier]))
            .ToList();

        var nodeIdByIdentifier = nodes.ToDictionary(
            n => n.Info.Identifier,
            n => n.Id);

        var flowLinks = dto.FlowLinks
            .Select(fl => FlowLink.Create(
                flowLinkIdByIdentifier[fl.Info.Identifier],
                fl.Info,
                fl.Visual,
                nodeIdByIdentifier[fl.InputNodeIdentifier],
                nodeIdByIdentifier[fl.OutputNodeIdentifier]))
            .ToList();

        return Graph.Create(
            new GraphId(Guid.NewGuid()),
            enums,
            inputPorts,
            outputPorts,
            nodes,
            nodeIdByIdentifier[dto.StartNodeIdentifier],
            dataLinks,
            flowLinks);
    }

    public static GraphDto ToDto(this Graph domain)
    {
        var enums = domain.Enums
            .Select(e => e.ToDto())
            .ToList();

        var flowLinkIdentifierById = domain.FlowLinks.ToDictionary(
            fl => fl.Id,
            fl => fl.Info.Identifier);

        var nodes = domain.Nodes
            .Select(NodeDto (node) =>
            {
                return node switch
                {
                    InteractionNode interactionNode => interactionNode.ToDto(),
                    StaticNode<TextData> staticNode => staticNode.ToDto(),
                    StaticNode<OptionData> staticNode => staticNode.ToDto(),
                    StaticNode<ImageData> staticNode => staticNode.ToDto(),
                    PromptNode promptNode => promptNode.ToDto(),
                    SwitchNode switchNode => switchNode.ToDto(switchNode.Bindings.ToDictionary(
                        b => b.Key,
                        b => flowLinkIdentifierById[b.Value])),
                    _ => throw new ArgumentOutOfRangeException(nameof(node))
                };
            })
            .ToList();

        var nodeIdentifierById = domain.Nodes.ToDictionary(
            n => n.Id,
            n => n.Info.Identifier);

        var inputPortIdentifierById = domain.InputPorts.ToDictionary(
            ip => ip.Id,
            ip => ip.Info.Identifier);

        var outputPortIdentifierById = domain.OutputPorts.ToDictionary(
            op => op.Id,
            op => op.Info.Identifier);

        var dataLinks = domain.DataLinks
            .Select(dl => new DataLinkDto(
                dl.Info,
                dl.Visual,
                inputPortIdentifierById[dl.InputPortId],
                outputPortIdentifierById[dl.OutputPortId]))
            .ToList();

        var flowLinks = domain.FlowLinks
            .Select(fl => new FlowLinkDto(
                fl.Info,
                fl.Visual,
                nodeIdentifierById[fl.InputNodeId],
                nodeIdentifierById[fl.OutputNodeId]))
            .ToList();

        return new GraphDto(
            nodeIdentifierById[domain.StartNodeId],
            nodes,
            dataLinks,
            flowLinks,
            enums);
    }
}