using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;

/// <summary>
/// A node that has outputs and can publish them to other nodes.
/// </summary>
public interface IOutputNode
{
    IEnumerable<OutputPortId> GetOutputPortIds();
    void PublishOutputs();
}