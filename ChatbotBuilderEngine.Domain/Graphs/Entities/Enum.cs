using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities;

public sealed class Enum : Entity<EnumId>
{
    public InfoMeta Info { get; } = null!;
    public IReadOnlySet<OptionData> Options { get; } = null!;

    private Enum(
        EnumId id,
        InfoMeta info,
        IReadOnlySet<OptionData> options)
        : base(id)
    {
        Info = info;
        Options = options;
    }

    /// <inheritdoc/>
    private Enum()
    {
    }

    public static Enum Create(
        EnumId id,
        InfoMeta info,
        IReadOnlySet<OptionData> options)
    {
        return new Enum(id, info, options);
    }

    public void EnsureValidBindings<T>(IReadOnlyDictionary<OptionData, T> mapping)
    {
        if (mapping.Count != Options.Count
            || Options.Any(option => !mapping.ContainsKey(option)))
        {
            throw new DomainException(GraphsDomainErrors.Enum.InvalidMapping);
        }
    }
}