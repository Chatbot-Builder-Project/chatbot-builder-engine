using Enum = ChatbotBuilderEngine.Domain.Graphs.Entities.Enum;

namespace ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;

/// <summary>
/// A node that uses an enumeration.
/// </summary>
public interface IEnumNode
{
    Enum Enum { get; }
}