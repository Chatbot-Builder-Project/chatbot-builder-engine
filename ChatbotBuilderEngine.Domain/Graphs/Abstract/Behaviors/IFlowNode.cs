namespace ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;

/// <summary>
/// A node that can exist in the flow graph,
/// and hence can determine the next node to be traversed to (its successor).
/// </summary>
public interface IFlowNode
{
    IFlowNode GetSuccessor();
}