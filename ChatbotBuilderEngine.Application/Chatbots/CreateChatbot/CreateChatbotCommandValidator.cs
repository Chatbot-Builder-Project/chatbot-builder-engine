using FluentValidation;

namespace ChatbotBuilderEngine.Application.Chatbots.CreateChatbot;

public sealed class CreateChatbotCommandValidator : AbstractValidator<CreateChatbotCommand>
{
    public CreateChatbotCommandValidator()
    {
        RuleFor(x => x.WorkflowId)
            .NotEmpty();
    }
}