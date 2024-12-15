using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities;

public sealed class Enum : Entity<EnumId>
{
    private readonly HashSet<OptionData> _options = [];

    public InfoMeta Info { get; } = null!;
    public IReadOnlySet<OptionData> Options => _options;

    private Enum(
        EnumId id,
        InfoMeta info)
        : base(id)
    {
        Info = info;
    }

    /// <inheritdoc/>
    private Enum()
    {
    }

    public static Enum Create(
        EnumId id,
        InfoMeta info,
        IReadOnlyList<OptionData> options)
    {
        var @enum = new Enum(id, info);

        foreach (var option in options)
        {
            @enum.AddOption(option);
        }

        return @enum;
    }

    private void AddOption(OptionData option)
    {
        if (!_options.Add(option))
        {
            throw new DomainException(GraphsDomainErrors.Enum.OptionAlreadyExists);
        }
    }

    public void EnsureValidBindings<T>(Dictionary<OptionData, T> mapping)
    {
        if (mapping.Count != _options.Count
            || _options.Any(option => !mapping.ContainsKey(option)))
        {
            throw new DomainException(GraphsDomainErrors.Enum.InvalidMapping);
        }
    }
}