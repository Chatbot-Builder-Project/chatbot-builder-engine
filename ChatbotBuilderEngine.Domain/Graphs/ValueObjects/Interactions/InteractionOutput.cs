using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.ValueObjects.Data;

namespace ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Interactions;

/// <summary>
/// Contains all data that should be outputted to the user.
/// And contains guiding information for what the user should input next.
/// </summary>
public sealed class InteractionOutput : ValueObject
{
    public TextData? TextOutput { get; }
    public bool TextExpected { get; }
    public bool OptionExpected { get; }
    public IReadOnlyDictionary<OptionData, InteractionOptionMeta>? ExpectedOptionMetas { get; }

    private InteractionOutput(
        TextData? textOutput,
        bool textExpected,
        bool optionExpected,
        IReadOnlyDictionary<OptionData, InteractionOptionMeta>? expectedOptionMetas)
    {
        TextOutput = textOutput;
        TextExpected = textExpected;
        OptionExpected = optionExpected;
        ExpectedOptionMetas = expectedOptionMetas;
    }

    /// <inheritdoc/>
    private InteractionOutput()
    {
    }

    public static InteractionOutput Create(
        TextData? textOutput,
        bool textExpected,
        bool optionExpected,
        IReadOnlyDictionary<OptionData, InteractionOptionMeta>? expectedOptionsMetas)
    {
        return new InteractionOutput(textOutput, textExpected, optionExpected, expectedOptionsMetas);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return (object?)TextOutput ?? false;
        yield return TextExpected;
        yield return OptionExpected;
        yield return (object?)ExpectedOptionMetas ?? false;
    }
}