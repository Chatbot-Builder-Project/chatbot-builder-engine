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
    }
}