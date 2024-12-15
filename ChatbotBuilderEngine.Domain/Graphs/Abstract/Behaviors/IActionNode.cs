namespace ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;

/// <summary>
/// A node that can be activated to perform some action task (before publishing its outputs).
/// The task typically involves using the node's inputs (but not necessarily).
/// </summary>
public interface IActionNode
{
    Task RunAsync();
}