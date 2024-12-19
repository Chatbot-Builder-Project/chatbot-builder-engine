namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;

public sealed class ImageData : Data
{
    public string Url { get; } = null!;

    private ImageData(string url)
    {
        Url = url;
    }

    /// <inheritdoc/>
    private ImageData()
    {
    }

    public static ImageData Create(string url) => new(url);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Url;
    }
}