using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;

/// <summary>
/// A node that might use one or more enums.
/// </summary>
public interface IEnumNode
{
    IEnumerable<EnumId> GetEnumIds();
}