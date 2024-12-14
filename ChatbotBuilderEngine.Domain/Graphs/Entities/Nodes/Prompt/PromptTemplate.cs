using System.Text.RegularExpressions;
using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes.Prompt;

public sealed partial class PromptTemplate : ValueObject
{
    public string Text { get; } = null!;

    private PromptTemplate(string text)
    {
        Text = text;
    }

    /// <inheritdoc/>
    private PromptTemplate()
    {
    }

    public static PromptTemplate Create(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Text cannot be null or empty.", nameof(text));
        }

        return new PromptTemplate(text);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Text;
    }

    [GeneratedRegex(@"\{\{(\w+)\}\}", RegexOptions.Compiled)]
    private static partial Regex PlaceholderRegex();

    /// <summary>
    /// Counts the number of unique placeholders in the template.
    /// </summary>
    /// <returns>The number of unique placeholders.</returns>
    public int CountDistinctPlaceholders()
    {
        return ExtractPlaceholders().Distinct().Count();
    }

    /// <summary>
    /// Retrieves all placeholders from the template.
    /// </summary>
    /// <returns>A collection of placeholder keys.</returns>
    public IEnumerable<string> ExtractPlaceholders()
    {
        return PlaceholderRegex()
            .Matches(Text)
            .Select(match => match.Groups[1].Value);
    }

    /// <summary>
    /// Injects values into the placeholders within the template.
    /// </summary>
    /// <param name="values">A dictionary of placeholder keys and their replacement values.</param>
    /// <returns>A string with placeholders replaced by the provided values.</returns>
    public string InjectValues(Dictionary<string, string> values)
    {
        var distinctPlaceholders = ExtractPlaceholders().Distinct().ToList();

        // Ensure all placeholders are provided in the dictionary
        if (distinctPlaceholders.Except(values.Keys).Any())
        {
            throw new DomainException(GraphsDomainErrors.PromptNode.MissingPlaceholderKeys);
        }

        // Ensure no unused keys in the dictionary
        if (values.Keys.Except(distinctPlaceholders).Any())
        {
            throw new DomainException(GraphsDomainErrors.PromptNode.UnusedKeysInDictionary);
        }

        return PlaceholderRegex().Replace(Text, match =>
        {
            var key = match.Groups[1].Value;
            return values.TryGetValue(key, out var replacement) ? replacement : match.Value;
        });
    }
}