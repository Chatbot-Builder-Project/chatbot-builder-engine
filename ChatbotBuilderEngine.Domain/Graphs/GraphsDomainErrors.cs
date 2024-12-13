using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs;

public static class GraphsDomainErrors
{
    public static class Port
    {
        public static readonly Error NodeIdMismatch = new(
            ErrorType.DomainValidation,
            "InputPort.NodeIdMismatch",
            "The node ID of the input port does not match its node's ID");
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
    }
}