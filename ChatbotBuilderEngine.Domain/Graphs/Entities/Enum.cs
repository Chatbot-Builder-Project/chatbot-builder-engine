using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities;

public sealed class Enum : Entity<EnumId>
{
    private readonly HashSet<OptionData> _options = [];
    public IReadOnlyCollection<OptionData> Options => _options.ToList();
    public InfoMeta Info { get; } = null!;

    private Enum(
        EnumId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info)
        : base(id, createdAt, updatedAt)
    {
        Info = info;
    }

    /// <inheritdoc/>
    private Enum()
    {
    }

    public static Enum Create(
        EnumId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        IReadOnlyList<OptionData> options)
    {
        var @enum = new Enum(id, createdAt, updatedAt, info);

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