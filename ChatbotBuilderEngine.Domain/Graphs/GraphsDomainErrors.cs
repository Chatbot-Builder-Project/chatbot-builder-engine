using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs;

public static class GraphsDomainErrors
{
    public static class Enum
    {
        public static readonly Error OptionAlreadyExists = new(
            ErrorType.DomainValidation,
            "Enum.OptionAlreadyExists",
            "This option already exists in the enum");

        public static readonly Error InvalidMapping = new(
            ErrorType.DomainValidation,
            "Enum.InvalidMapping",
            "The given mapping is not valid for this enum");
    }

    public static class Port
    {
        public static readonly Error NodeIdMismatch = new(
            ErrorType.DomainValidation,
            "InputPort.NodeIdMismatch",
            "The node ID of the input port does not match its node's ID");
    }

    public static class InputPort
    {
        public static readonly Error HasNoData = new(
            ErrorType.DomainValidation,
            "InputPort.HasNoData",
            "Input port has not received any data yet");

        public static readonly Error IsNotInputPort = new(
            ErrorType.DomainValidation,
            "InputPort.IsNotInputPort",
            "The port type is not a valid input port");
    }

    public static class OutputPort
    {
        public static readonly Error IsNotOutputPort = new(
            ErrorType.DomainValidation,
            "OutputPort.IsNotInputPort",
            "The port type is not a valid output port");

        public static readonly Error InputPortAlreadySubscribed = new(
            ErrorType.DomainValidation,
            "OutputPort.InputPortAlreadySubscribed",
            "This input port is already subscribed to this output port");
    }

    public static class Graph
    {
        public static readonly Error EnumAlreadyExists = new(
            ErrorType.DomainValidation,
            "Graph.EnumAlreadyExists",
            "This enum already exists in the graph");

        public static readonly Error EnumDoesNotExist = new(
            ErrorType.DomainValidation,
            "Graph.EnumDoesNotExist",
            "This enum does not exist in the graph");

        public static readonly Error NodeAlreadyExists = new(
            ErrorType.DomainValidation,
            "Graph.NodeAlreadyExists",
            "This node already exists in the graph");

        public static readonly Error NodeDoesNotExist = new(
            ErrorType.DomainValidation,
            "Graph.NodeDoesNotExist",
            "This node does not exist in the graph");

        public static readonly Error StartNodeIsNotInteractionNode = new(
            ErrorType.DomainValidation,
            "Graph.StartNodeIsNotInteractionNode",
            "The start node of the graph must be an interaction node");

        public static readonly Error InputPortAlreadyExists = new(
            ErrorType.DomainValidation,
            "Graph.InputPortAlreadyExists",
            "This input port already exists in the graph");

        public static readonly Error InputPortDoesNotExist = new(
            ErrorType.DomainValidation,
            "Graph.InputPortDoesNotExist",
            "This input port does not exist in the graph");

        public static readonly Error OutputPortAlreadyExists = new(
            ErrorType.DomainValidation,
            "Graph.OutputPortAlreadyExists",
            "This output port already exists in the graph");

        public static readonly Error OutputPortDoesNotExist = new(
            ErrorType.DomainValidation,
            "Graph.OutputPortDoesNotExist",
            "This output port does not exist in the graph");

        public static readonly Error DataLinkAlreadyExists = new(
            ErrorType.DomainValidation,
            "Graph.DataLinkAlreadyExists",
            "This data link already exists in the graph");

        public static readonly Error DataLinkTypeMismatch = new(
            ErrorType.DomainValidation,
            "Graph.DataLinkTypeMismatch",
            "Data types of the input and output ports of the data link do not match");

        public static readonly Error FlowLinkAlreadyExists = new(
            ErrorType.DomainValidation,
            "Graph.FlowLinkAlreadyExists",
            "This flow link already exists in the graph");

        public static readonly Error FlowLinkTypeMismatch = new(
            ErrorType.DomainValidation,
            "Graph.FlowLinkTypeMismatch",
            "The input or output nodes of the flow link are not valid flow nodes");
    }

    public static class PromptNode
    {
        public static readonly Error SuccessorNotSet = new(
            ErrorType.DomainValidation,
            "PromptNode.SuccessorNotSet",
            "The successor of the node has not been set yet");

        public static readonly Error DoesNotMatchPlaceholdersCount = new(
            ErrorType.DomainValidation,
            "PromptNode.DoesNotMatchPlaceholdersCount",
            "The number of placeholders in the prompt does not match the given number of data");

        public static readonly Error MissingPlaceholderKeys = new(
            ErrorType.DomainValidation,
            "PromptNode.MissingPlaceholderKeys",
            "One or more placeholders in the prompt do not have corresponding keys in the provided data");

        public static readonly Error UnusedKeysInDictionary = new(
            ErrorType.DomainValidation,
            "PromptNode.UnusedKeysInDictionary",
            "One or more keys in the provided data are not used in the prompt");
    }

    public static class SwitchNode
    {
        public static readonly Error InvalidBindingsCount = new(
            ErrorType.DomainValidation,
            "SwitchNode.InvalidBindingsCount",
            "The number of bindings does not match the number of options in the enum");

        public static readonly Error FlowLinkAlreadyBound = new(
            ErrorType.DomainValidation,
            "SwitchNode.FlowLinkAlreadyBound",
            "This flow link is already bound to a successor node");

        public static readonly Error FlowLinkNotBound = new(
            ErrorType.DomainValidation,
            "SwitchNode.FlowLinkNotBound",
            "The selected flow link is not bound to any successor node");

        public static readonly Error HasNotBeenActivated = new(
            ErrorType.DomainValidation,
            "SwitchNode.HasNotBeenActivated",
            "This switch node has not been activated yet");

        public static readonly Error OptionNotBound = new(
            ErrorType.DomainValidation,
            "SwitchNode.OptionNotBound",
            "The selected option is not bound to any flow link");
    }

    public static class InteractionNode
    {
        public static readonly Error InputPortsIsMissing = new(
            ErrorType.DomainValidation,
            "InteractionNode.InputPortsIsMissing",
            "At least one input port is required for the interaction node");

        public static readonly Error OutputPortsIsMissing = new(
            ErrorType.DomainValidation,
            "InteractionNode.OutputPortsIsMissing",
            "At least one output port is required for the interaction node");

        public static readonly Error SuccessorNotSet = new(
            ErrorType.DomainValidation,
            "InteractionNode.SuccessorNotSet",
            "The successor of the node has not been set yet");


        public static readonly Error OutputEnumIsMissing = new(
            ErrorType.DomainValidation,
            "InteractionNode.OutputEnumIsMissing",
            "The option enum is missing for the interaction node");

        public static readonly Error OutputEnumIsUnnecessary = new(
            ErrorType.DomainValidation,
            "InteractionNode.OutputEnumIsUnnecessary",
            "The option enum is unnecessary for the interaction node");

        public static readonly Error OptionDataMetasIsUnnecessary = new(
            ErrorType.DomainValidation,
            "InteractionNode.OptionDataMetasIsUnnecessary",
            "The option data metas are provided without an option enum");

        public static readonly Error OptionDataMetasIsMissing = new(
            ErrorType.DomainValidation,
            "InteractionNode.OptionDataMetasIsMissing",
            "The option data metas are missing for the interaction node");

        public static readonly Error InputTextIsMissing = new(
            ErrorType.DomainValidation,
            "InteractionNode.InputTextIsMissing",
            "The given input is missing text input");

        public static readonly Error InputTextIsUnnecessary = new(
            ErrorType.DomainValidation,
            "InteractionNode.InputTextIsUnnecessary",
            "The given input is unnecessary text input");

        public static readonly Error InputOptionIsMissing = new(
            ErrorType.DomainValidation,
            "InteractionNode.InputOptionIsMissing",
            "The given input is missing option input");

        public static readonly Error InputOptionIsUnnecessary = new(
            ErrorType.DomainValidation,
            "InteractionNode.InputOptionIsUnnecessary",
            "The given input is unnecessary option input");
    }
}