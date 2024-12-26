using FluentValidation;

namespace ChatbotBuilderEngine.Application.Conversations.StartConversation;

public sealed class StartConversationCommandValidator : AbstractValidator<StartConversationCommand>
{
    public StartConversationCommandValidator()
    {
        RuleFor(x => x.ChatbotId)
            .NotEmpty();

        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.Name)
            .MaximumLength(100);
    }
}