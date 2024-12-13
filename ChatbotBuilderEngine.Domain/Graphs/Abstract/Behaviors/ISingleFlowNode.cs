namespace ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;

/// <summary>
/// A flow node that has a single successor.
/// </summary>
public interface ISingleFlowNode : IFlowNode
{
    void SetSuccessor(IFlowNode successor);
}