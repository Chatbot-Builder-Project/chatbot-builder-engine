namespace ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;

/// <summary>
/// A node that can be activated to perform some action,
/// which typically involves using the node's inputs (but not necessarily).
/// </summary>
public interface IActiveNode
{
    Task ActivateAsync();
}