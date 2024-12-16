using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;

public sealed class Version : ValueObject
{
    public int Major { get; }

    private Version(int major)
    {
        Major = major;
    }

    public static Version Create(int major)
    {
        if (major < 1)
        {
            throw new DomainException(ChatbotsDomainErrors.Version.MajorMustBePositive);
        }

        return new Version(major);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Major;
    }
}