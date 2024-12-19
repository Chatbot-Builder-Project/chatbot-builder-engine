using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs;

public static class GraphsDomainErrors
{
    public static class Enum
    {
        public static readonly Error InvalidMapping = Error.DomainInvariant(
            "Enum.InvalidMapping",
            "The given mapping is not valid for this enum");
    }

    public static class Port
    {
        public static readonly Error NodeIdMismatch = Error.DomainInvariant(
            "InputPort.NodeIdMismatch",
            "The node ID of the input port does not match its node's ID");
    }

    public static class InputPort
    {
        public static readonly Error HasNoData = Error.DomainInvariant(
            "InputPort.HasNoData",
            "Input port has not received any data yet");

        public static readonly Error IsNotInputPort = Error.DomainInvariant(
            "InputPort.IsNotInputPort",
            "The port type is not a valid input port");
    }

    public static class OutputPort
    {
        public static readonly Error IsNotOutputPort = Error.DomainInvariant(
            "OutputPort.IsNotInputPort",
            "The port type is not a valid output port");

        public static readonly Error InputPortAlreadySubscribed = Error.DomainInvariant(
            "OutputPort.InputPortAlreadySubscribed",
            "This input port is already subscribed to this output port");
    }

    public static class Graph
    {
        public static readonly Error EnumAlreadyExists = Error.DomainInvariant(
            "Graph.EnumAlreadyExists",
            "This enum already exists in the graph");

        public static readonly Error EnumDoesNotExist = Error.DomainInvariant(
            "Graph.EnumDoesNotExist",
            "This enum does not exist in the graph");

        public static readonly Error NodeAlreadyExists = Error.DomainInvariant(
            "Graph.NodeAlreadyExists",
            "This node already exists in the graph");

        public static readonly Error NodeDoesNotExist = Error.DomainInvariant(
            "Graph.NodeDoesNotExist",
            "This node does not exist in the graph");

        public static readonly Error StartNodeIsNotInteractionNode = Error.DomainInvariant(
            "Graph.StartNodeIsNotInteractionNode",
            "The start node of the graph must be an interaction node");

        public static readonly Error InputPortAlreadyExists = Error.DomainInvariant(
            "Graph.InputPortAlreadyExists",
            "This input port already exists in the graph");

        public static readonly Error InputPortDoesNotExist = Error.DomainInvariant(
            "Graph.InputPortDoesNotExist",
            "This input port does not exist in the graph");

        public static readonly Error OutputPortAlreadyExists = Error.DomainInvariant(
            "Graph.OutputPortAlreadyExists",
            "This output port already exists in the graph");

        public static readonly Error OutputPortDoesNotExist = Error.DomainInvariant(
            "Graph.OutputPortDoesNotExist",
            "This output port does not exist in the graph");

        public static readonly Error DataLinkAlreadyExists = Error.DomainInvariant(
            "Graph.DataLinkAlreadyExists",
            "This data link already exists in the graph");

        public static readonly Error DataLinkTypeMismatch = Error.DomainInvariant(
            "Graph.DataLinkTypeMismatch",
            "Data types of the input and output ports of the data link do not match");

        public static readonly Error FlowLinkAlreadyExists = Error.DomainInvariant(
            "Graph.FlowLinkAlreadyExists",
            "This flow link already exists in the graph");

        public static readonly Error FlowLinkCannotBeUsedForSetupNode = Error.DomainInvariant(
            "Graph.FlowLinkCannotBeUsedForSetupNode",
            "A flow link cannot be used for a setup node");

        public static readonly Error SwitchNodeDoesNotContainFlowLink = Error.DomainInvariant(
            "Graph.SwitchNodeDoesNotContainFlowLink",
            "The switch node does not contain the given flow link");

        public static readonly Error ExtraInputPorts = Error.DomainInvariant(
            "Graph.ExtraInputPorts",
            "The graph has extra input ports that are not connected to any node");

        public static readonly Error ExtraOutputPorts = Error.DomainInvariant(
            "Graph.ExtraOutputPorts",
            "The graph has extra output ports that are not connected to any node");

        public static readonly Error UnconnectedInputPorts = Error.DomainInvariant(
            "Graph.UnconnectedInputPorts",
            "The graph has input ports that are not connected with a data link");

        public static readonly Error SwitchNodeContainsExtraFlowLinkIds = Error.DomainInvariant(
            "Graph.SwitchNodeContainsExtraFlowLinkIds",
            "The switch node contains extra flow link IDs that are not connected to any flow link");

        public static readonly Error NonSwitchNodeHasMultipleOutputFlowLinks = Error.DomainInvariant(
            "PromptNode.NonSwitchNodeHasMultipleOutputFlowLinks",
            "A non-switch node cannot have multiple output flow links");

        public static readonly Error InteractionNodeNotFound = Error.DomainInvariant(
            "Conversation.InteractionNodeNotFound",
            "Interaction node not found");
    }

    public static class PromptNode
    {
        public static readonly Error NodeHasNotBeenActivated = Error.DomainInvariant(
            "PromptNode.NodeHasNotBeenActivated",
            "This prompt node has not been activated yet");

        public static readonly Error DuplicateInputPorts = Error.DomainInvariant(
            "PromptNode.DuplicateInputPorts",
            "The input ports of the prompt node must be unique");

        public static readonly Error MissingPlaceholderKeys = Error.DomainInvariant(
            "PromptNode.MissingPlaceholderKeys",
            "One or more placeholders in the prompt do not have corresponding keys in the provided data");

        public static readonly Error UnusedKeysInDictionary = Error.DomainInvariant(
            "PromptNode.UnusedKeysInDictionary",
            "One or more keys in the provided data are not used in the prompt");
    }

    public static class SwitchNode
    {
        public static readonly Error HasNotBeenActivated = Error.DomainInvariant(
            "SwitchNode.HasNotBeenActivated",
            "This switch node has not been activated yet");

        public static readonly Error OptionNotBound = Error.DomainInvariant(
            "SwitchNode.OptionNotBound",
            "The selected option is not bound to any flow link");
    }

    public static class InteractionNode
    {
        public static readonly Error InteractionInputHasNotBeenSet = Error.DomainInvariant(
            "InteractionNode.InteractionInputHasNotBeenSet",
            "The interaction input has not been set for the interaction node");

        public static readonly Error InputPortsIsMissing = Error.DomainInvariant(
            "InteractionNode.InputPortsIsMissing",
            "At least one input port is required for the interaction node");

        public static readonly Error OutputPortsIsMissing = Error.DomainInvariant(
            "InteractionNode.OutputPortsIsMissing",
            "At least one output port is required for the interaction node");

        public static readonly Error OutputEnumIsMissing = Error.DomainInvariant(
            "InteractionNode.OutputEnumIsMissing",
            "The option enum is missing for the interaction node");

        public static readonly Error OutputEnumIsUnnecessary = Error.DomainInvariant(
            "InteractionNode.OutputEnumIsUnnecessary",
            "The option enum is unnecessary for the interaction node");

        public static readonly Error OptionDataMetasIsUnnecessary = Error.DomainInvariant(
            "InteractionNode.OptionDataMetasIsUnnecessary",
            "The option data metas are provided without an option enum");

        public static readonly Error OptionDataMetasIsMissing = Error.DomainInvariant(
            "InteractionNode.OptionDataMetasIsMissing",
            "The option data metas are missing for the interaction node");

        public static readonly Error InputTextIsMissing = Error.DomainInvariant(
            "InteractionNode.InputTextIsMissing",
            "The given input is missing text input");

        public static readonly Error InputTextIsUnnecessary = Error.DomainInvariant(
            "InteractionNode.InputTextIsUnnecessary",
            "The given input is unnecessary text input");

        public static readonly Error InputOptionIsMissing = Error.DomainInvariant(
            "InteractionNode.InputOptionIsMissing",
            "The given input is missing option input");

        public static readonly Error InputOptionIsUnnecessary = Error.DomainInvariant(
            "InteractionNode.InputOptionIsUnnecessary",
            "The given input is unnecessary option input");
    }

    public static class GraphTraversal
    {
        public static readonly Error GraphNotSet = Error.DomainInvariant(
            "GraphTraversal.GraphNotSet",
            "Graph not set");
    }
}