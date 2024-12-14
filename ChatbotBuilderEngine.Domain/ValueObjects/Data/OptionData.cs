using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderEngine.Domain.ValueObjects.Data;

public sealed class OptionData : Data
{
    public EnumId EnumId { get; } = null!;
    public string Value { get; } = null!;

    private OptionData(EnumId enumId, string value)
    {
        EnumId = enumId;
        Value = value;
    }

    /// <inheritdoc/>
    private OptionData()
    {
    }

    public static OptionData Create(EnumId enumId, string value) => new(enumId, value);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return EnumId;
        yield return Value;
    }
}