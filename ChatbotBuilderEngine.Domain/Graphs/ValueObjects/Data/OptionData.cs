using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;

public sealed class OptionData : Data
{
    public EnumId EnumId { get; }
    public string Value { get; }

    private OptionData(EnumId enumId, string value)
    {
        EnumId = enumId;
        Value = value;
    }

    public static OptionData Create(EnumId enumId, string value) => new(enumId, value);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return EnumId;
        yield return Value;
    }
}