using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Chatbots;

public static class ChatbotsDomainErrors
{
    public static class Version
    {
        public static readonly Error MajorMustBePositive = new(
            ErrorType.DomainValidation,
            "Version.MajorMustBePositive",
            "Chatbot major version must be positive.");
    }
}