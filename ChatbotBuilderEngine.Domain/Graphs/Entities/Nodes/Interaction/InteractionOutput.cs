using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes.Interaction;

/// <summary>
/// Contains all data that should be outputted to the user.
/// And contains guiding information for what the user should input next.
/// </summary>
public sealed class InteractionOutput : ValueObject
{
    public TextData? TextOutput { get; }
    public bool TextExpected { get; }
    public bool OptionExpected { get; }

    private InteractionOutput(TextData? textOutput, bool textExpected, bool optionExpected)
    {
        TextOutput = textOutput;
        TextExpected = textExpected;
        OptionExpected = optionExpected;
    }

    public static InteractionOutput Create(TextData? textOutput, bool textExpected, bool optionExpected)
    {
        return new InteractionOutput(textOutput, textExpected, optionExpected);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return (object?)TextOutput ?? false;
        yield return TextExpected;
        yield return OptionExpected;
    }
}