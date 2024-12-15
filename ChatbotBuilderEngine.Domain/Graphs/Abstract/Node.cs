using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Domain.Graphs.Abstract;

public abstract class Node : Entity<NodeId>
{
    public InfoMeta Info { get; } = null!;
    public VisualMeta Visual { get; } = null!;

    protected Node(
        NodeId id,
        InfoMeta info,
        VisualMeta visual)
        : base(id)
    {
        Info = info;
        Visual = visual;
    }

    /// <inheritdoc/>
    protected Node()
    {
    }

    /// <summary>
    /// Any action that need to be executed before all other tasks should be implemented here.
    /// </summary>
    /// <remarks>
    /// The graph will call this method before publishing outputs, or getting the successor node, etc.
    /// </remarks>
    public virtual Task RunAsync() => Task.CompletedTask;
}