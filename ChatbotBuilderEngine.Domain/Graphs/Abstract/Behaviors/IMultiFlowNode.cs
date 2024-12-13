using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;

/// <summary>
/// A flow node that has multiple successors.
/// </summary>
public interface IMultiFlowNode : IFlowNode
{
    void Bind(FlowLinkId flowLinkId, IFlowNode node);
}