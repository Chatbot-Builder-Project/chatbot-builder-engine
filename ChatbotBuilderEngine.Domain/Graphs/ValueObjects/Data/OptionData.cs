namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;

public sealed class OptionData : Data
{
    public string Value { get; } = null!;

    private OptionData(string value)
    {
        Value = value;
    }

    /// <inheritdoc/>
    private OptionData()
    {
    }

    public static OptionData Create(string value) => new(value);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}