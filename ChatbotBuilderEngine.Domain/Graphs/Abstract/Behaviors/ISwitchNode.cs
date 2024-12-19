using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;

/// <summary>
/// A node that determines the flow link to follow based on its current state.
/// </summary>
public interface ISwitchNode
{
    IEnumerable<FlowLinkId> GetFlowLinkIds();
    FlowLinkId GetSelectedFlowLinkId();
}