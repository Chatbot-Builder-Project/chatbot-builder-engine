namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;

public sealed class TextData : Data
{
    public string Text { get; }

    private TextData(string text)
    {
        Text = text;
    }

    public static TextData Create(string text) => new(text);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Text;
    }
}