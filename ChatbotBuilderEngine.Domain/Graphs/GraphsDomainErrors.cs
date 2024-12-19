using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs;

public static class GraphsDomainErrors
{
    public static class Enum
    {
        public static readonly Error InvalidMapping = Error.DomainValidation(
            "Enum.InvalidMapping",
            "The given mapping is not valid for this enum");
    }

    public static class Port
    {
        public static readonly Error NodeIdMismatch = Error.DomainValidation(
            "InputPort.NodeIdMismatch",
            "The node ID of the input port does not match its node's ID");
    }

    public static class InputPort
    {
        public static readonly Error HasNoData = Error.DomainValidation(
            "InputPort.HasNoData",
            "Input port has not received any data yet");

        public static readonly Error IsNotInputPort = Error.DomainValidation(
            "InputPort.IsNotInputPort",
            "The port type is not a valid input port");
    }

    public static class OutputPort
    {
        public static readonly Error IsNotOutputPort = Error.DomainValidation(
            "OutputPort.IsNotInputPort",
            "The port type is not a valid output port");

        public static readonly Error InputPortAlreadySubscribed = Error.DomainValidation(
            "OutputPort.InputPortAlreadySubscribed",
            "This input port is already subscribed to this output port");
    }

    public static class Graph
    {
        public static readonly Error EnumAlreadyExists = Error.DomainValidation(
            "Graph.EnumAlreadyExists",
            "This enum already exists in the graph");

        public static readonly Error EnumDoesNotExist = Error.DomainValidation(
            "Graph.EnumDoesNotExist",
            "This enum does not exist in the graph");

        public static readonly Error NodeAlreadyExists = Error.DomainValidation(
            "Graph.NodeAlreadyExists",
            "This node already exists in the graph");

        public static readonly Error NodeDoesNotExist = Error.DomainValidation(
            "Graph.NodeDoesNotExist",
            "This node does not exist in the graph");

        public static readonly Error StartNodeIsNotInteractionNode = Error.DomainValidation(
            "Graph.StartNodeIsNotInteractionNode",
            "The start node of the graph must be an interaction node");

        public static readonly Error InputPortAlreadyExists = Error.DomainValidation(
            "Graph.InputPortAlreadyExists",
            "This input port already exists in the graph");

        public static readonly Error InputPortDoesNotExist = Error.DomainValidation(
            "Graph.InputPortDoesNotExist",
            "This input port does not exist in the graph");

        public static readonly Error OutputPortAlreadyExists = Error.DomainValidation(
            "Graph.OutputPortAlreadyExists",
            "This output port already exists in the graph");

        public static readonly Error OutputPortDoesNotExist = Error.DomainValidation(
            "Graph.OutputPortDoesNotExist",
            "This output port does not exist in the graph");

        public static readonly Error DataLinkAlreadyExists = Error.DomainValidation(
            "Graph.DataLinkAlreadyExists",
            "This data link already exists in the graph");

        public static readonly Error DataLinkTypeMismatch = Error.DomainValidation(
            "Graph.DataLinkTypeMismatch",
            "Data types of the input and output ports of the data link do not match");

        public static readonly Error FlowLinkAlreadyExists = Error.DomainValidation(
            "Graph.FlowLinkAlreadyExists",
            "This flow link already exists in the graph");

        public static readonly Error FlowLinkCannotBeUsedForSetupNode = Error.DomainValidation(
            "Graph.FlowLinkCannotBeUsedForSetupNode",
            "A flow link cannot be used for a setup node");

        public static readonly Error SwitchNodeDoesNotContainFlowLink = Error.DomainValidation(
            "Graph.SwitchNodeDoesNotContainFlowLink",
            "The switch node does not contain the given flow link");

        public static readonly Error ExtraInputPorts = Error.DomainValidation(
            "Graph.ExtraInputPorts",
            "The graph has extra input ports that are not connected to any node");

        public static readonly Error ExtraOutputPorts = Error.DomainValidation(
            "Graph.ExtraOutputPorts",
            "The graph has extra output ports that are not connected to any node");

        public static readonly Error UnconnectedInputPorts = Error.DomainValidation(
            "Graph.UnconnectedInputPorts",
            "The graph has input ports that are not connected with a data link");

        public static readonly Error SwitchNodeContainsExtraFlowLinkIds = Error.DomainValidation(
            "Graph.SwitchNodeContainsExtraFlowLinkIds",
            "The switch node contains extra flow link IDs that are not connected to any flow link");

        public static readonly Error NonSwitchNodeHasMultipleOutputFlowLinks = Error.DomainValidation(
            "PromptNode.NonSwitchNodeHasMultipleOutputFlowLinks",
            "A non-switch node cannot have multiple output flow links");

        public static readonly Error InteractionNodeNotFound = Error.DomainValidation(
            "Conversation.InteractionNodeNotFound",
            "Interaction node not found");
    }

    public static class PromptNode
    {
        public static readonly Error NodeHasNotBeenActivated = Error.DomainValidation(
            "PromptNode.NodeHasNotBeenActivated",
            "This prompt node has not been activated yet");

        public static readonly Error DuplicateInputPorts = Error.DomainValidation(
            "PromptNode.DuplicateInputPorts",
            "The input ports of the prompt node must be unique");

        public static readonly Error MissingPlaceholderKeys = Error.DomainValidation(
            "PromptNode.MissingPlaceholderKeys",
            "One or more placeholders in the prompt do not have corresponding keys in the provided data");

        public static readonly Error UnusedKeysInDictionary = Error.DomainValidation(
            "PromptNode.UnusedKeysInDictionary",
            "One or more keys in the provided data are not used in the prompt");
    }

    public static class SwitchNode
    {
        public static readonly Error HasNotBeenActivated = Error.DomainValidation(
            "SwitchNode.HasNotBeenActivated",
            "This switch node has not been activated yet");

        public static readonly Error OptionNotBound = Error.DomainValidation(
            "SwitchNode.OptionNotBound",
            "The selected option is not bound to any flow link");
    }

    public static class InteractionNode
    {
        public static readonly Error InteractionInputHasNotBeenSet = Error.DomainValidation(
            "InteractionNode.InteractionInputHasNotBeenSet",
            "The interaction input has not been set for the interaction node");

        public static readonly Error InputPortsIsMissing = Error.DomainValidation(
            "InteractionNode.InputPortsIsMissing",
            "At least one input port is required for the interaction node");

        public static readonly Error OutputPortsIsMissing = Error.DomainValidation(
            "InteractionNode.OutputPortsIsMissing",
            "At least one output port is required for the interaction node");

        public static readonly Error OutputEnumIsMissing = Error.DomainValidation(
            "InteractionNode.OutputEnumIsMissing",
            "The option enum is missing for the interaction node");

        public static readonly Error OutputEnumIsUnnecessary = Error.DomainValidation(
            "InteractionNode.OutputEnumIsUnnecessary",
            "The option enum is unnecessary for the interaction node");

        public static readonly Error OptionDataMetasIsUnnecessary = Error.DomainValidation(
            "InteractionNode.OptionDataMetasIsUnnecessary",
            "The option data metas are provided without an option enum");

        public static readonly Error OptionDataMetasIsMissing = Error.DomainValidation(
            "InteractionNode.OptionDataMetasIsMissing",
            "The option data metas are missing for the interaction node");

        public static readonly Error InputTextIsMissing = Error.DomainValidation(
            "InteractionNode.InputTextIsMissing",
            "The given input is missing text input");

        public static readonly Error InputTextIsUnnecessary = Error.DomainValidation(
            "InteractionNode.InputTextIsUnnecessary",
            "The given input is unnecessary text input");

        public static readonly Error InputOptionIsMissing = Error.DomainValidation(
            "InteractionNode.InputOptionIsMissing",
            "The given input is missing option input");

        public static readonly Error InputOptionIsUnnecessary = Error.DomainValidation(
            "InteractionNode.InputOptionIsUnnecessary",
            "The given input is unnecessary option input");
    }

    public static class GraphTraversal
    {
        public static readonly Error GraphNotSet = Error.DomainValidation(
            "GraphTraversal.GraphNotSet",
            "Graph not set");
    }
}