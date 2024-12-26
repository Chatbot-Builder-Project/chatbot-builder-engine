using FluentValidation;

namespace ChatbotBuilderEngine.Application.Conversations.UpdateConversation;

public sealed class UpdateConversationCommandValidator : AbstractValidator<UpdateConversationCommand>
{
    public UpdateConversationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.Name)
            .MaximumLength(100);
    }
}