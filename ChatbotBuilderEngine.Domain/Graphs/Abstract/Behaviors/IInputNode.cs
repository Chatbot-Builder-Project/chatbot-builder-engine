using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;

/// <summary>
/// A node that can have inputs.
/// </summary>
public interface IInputNode
{
    IEnumerable<InputPortId> GetInputPortIds();
}