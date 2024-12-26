using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Application.Chatbots;

public static class ChatbotsApplicationErrors
{
    public static readonly Error WorkflowNotFound = Error.ApplicationValidation(
        "Chatbots.WorkflowNotFound",
        "Workflow not found.");

    public static readonly Error ChatbotNotFound = Error.ApplicationValidation(
        "Chatbots.ChatbotNotFound",
        "Chatbot not found.");
}