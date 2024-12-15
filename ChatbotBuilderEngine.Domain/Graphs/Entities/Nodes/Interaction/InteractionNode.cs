using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes.Interaction;

public sealed class InteractionNode : Node,
    IInputNode, IEnumNode, IOutputNode
{
    public InputPort<TextData>? TextInputPort { get; }
    public OutputPort<TextData>? TextOutputPort { get; }

    public Enum? OutputEnum { get; }
    public OutputPort<OptionData>? OptionOutputPort { get; }
    public Dictionary<OptionData, InteractionOptionMeta>? OutputOptionMetas { get; }

    public InteractionInput? InteractionInput { get; private set; }

    private InteractionNode(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        InputPort<TextData>? textInputPort,
        OutputPort<TextData>? textOutputPort,
        Enum? outputEnum,
        OutputPort<OptionData>? optionOutputPort,
        Dictionary<OptionData, InteractionOptionMeta>? outputOptionMetas)
        : base(id, info, visual)
    {
        TextInputPort = textInputPort;
        TextOutputPort = textOutputPort;
        OutputEnum = outputEnum;
        OptionOutputPort = optionOutputPort;
        OutputOptionMetas = outputOptionMetas;
    }

    /// <inheritdoc/>
    private InteractionNode()
    {
    }

    public static InteractionNode Create(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        InputPort<TextData>? textInputPort,
        OutputPort<TextData>? textOutputPort,
        Enum? outputEnum,
        OutputPort<OptionData>? optionOutputPort,
        Dictionary<OptionData, InteractionOptionMeta>? outputOptionMetas)
    {
        if (textInputPort is null)
        {
            throw new DomainException(GraphsDomainErrors.InteractionNode.InputPortsIsMissing);
        }

        if (textOutputPort is null && optionOutputPort is null)
        {
            throw new DomainException(GraphsDomainErrors.InteractionNode.OutputPortsIsMissing);
        }

        if (optionOutputPort is null)
        {
            if (outputEnum is not null)
            {
                throw new DomainException(GraphsDomainErrors.InteractionNode.OutputEnumIsUnnecessary);
            }

            if (outputOptionMetas is not null)
            {
                throw new DomainException(GraphsDomainErrors.InteractionNode.OptionDataMetasIsUnnecessary);
            }
        }
        else
        {
            if (outputEnum is null)
            {
                throw new DomainException(GraphsDomainErrors.InteractionNode.OutputEnumIsMissing);
            }

            if (outputOptionMetas is null)
            {
                throw new DomainException(GraphsDomainErrors.InteractionNode.OptionDataMetasIsMissing);
            }
        }

        if (outputOptionMetas is not null)
        {
            outputEnum!.EnsureValidBindings(outputOptionMetas);
        }

        return new InteractionNode(
            id,
            info,
            visual,
            textInputPort,
            textOutputPort,
            outputEnum,
            optionOutputPort,
            outputOptionMetas);
    }

    public InteractionOutput GetInteractionOutput()
    {
        return InteractionOutput.Create(
            TextInputPort?.GetData(),
            TextOutputPort is not null,
            OptionOutputPort is not null);
    }

    public void SetInteractionInput(InteractionInput input)
    {
        if (TextOutputPort is not null && input.Text is null)
        {
            throw new DomainException(GraphsDomainErrors.InteractionNode.InputTextIsMissing);
        }

        if (TextOutputPort is null && input.Text is not null)
        {
            throw new DomainException(GraphsDomainErrors.InteractionNode.InputTextIsUnnecessary);
        }

        if (OptionOutputPort is not null && input.Option is null)
        {
            throw new DomainException(GraphsDomainErrors.InteractionNode.InputOptionIsMissing);
        }

        if (OptionOutputPort is null && input.Option is not null)
        {
            throw new DomainException(GraphsDomainErrors.InteractionNode.InputOptionIsUnnecessary);
        }

        InteractionInput = input;
    }

    public IEnumerable<InputPortId> GetInputPortIds()
    {
        if (TextInputPort is not null)
        {
            yield return TextInputPort.Id;
        }
    }

    public IEnumerable<OutputPortId> GetOutputPortIds()
    {
        if (TextOutputPort is not null)
        {
            yield return TextOutputPort.Id;
        }

        if (OptionOutputPort is not null)
        {
            yield return OptionOutputPort.Id;
        }
    }

    public void PublishOutputs()
    {
        if (InteractionInput is null)
        {
            throw new DomainException(GraphsDomainErrors.InteractionNode.InteractionInputHasNotBeenSet);
        }

        // if XOutputPort is not null, then InteractionInput.X will never be null
        TextOutputPort?.Publish(InteractionInput.Text!);
        OptionOutputPort?.Publish(InteractionInput.Option!);
    }

    public IEnumerable<EnumId> GetEnumIds()
    {
        if (OutputEnum is not null)
        {
            yield return OutputEnum.Id;
        }
    }
}