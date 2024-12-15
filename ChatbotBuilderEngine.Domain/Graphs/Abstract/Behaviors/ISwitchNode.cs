using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;

namespace ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;

/// <summary>
/// A node that determines the flow link to follow based on the option selected.
/// </summary>
public interface ISwitchNode
{
    IEnumerable<FlowLinkId> GetFlowLinkIds();
    FlowLinkId GetFlowLinkId(OptionData option);
}