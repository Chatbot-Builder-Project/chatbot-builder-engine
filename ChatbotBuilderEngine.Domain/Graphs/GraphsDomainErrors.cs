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

    }

    public static class OutputPort
    {
        public static readonly Error InputPortAlreadySubscribed = new(
            ErrorType.DomainValidation,
            "OutputPort.InputPortAlreadySubscribed",
            "This input port is already subscribed to this output port");
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
}