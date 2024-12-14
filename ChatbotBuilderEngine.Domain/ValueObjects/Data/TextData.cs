namespace ChatbotBuilderEngine.Domain.ValueObjects.Data;

public sealed class TextData : Data
{
    public string Text { get; } = null!;

    private TextData(string text)
    {
        Text = text;
    }

    /// <inheritdoc/>
    private TextData()
    {
    }

    public static TextData Create(string text) => new(text);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Text;
    }
}