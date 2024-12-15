using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;

namespace ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;

/// <summary>
/// A flow node that determines the flow link to follow based on the option selected.
/// </summary>
public interface IMultiFlowNode
{
    FlowLinkId GetFlowLinkId(OptionData option);
}