using FluentValidation;

namespace ChatbotBuilderEngine.Application.Conversations.SendMessage;

public sealed class SendMessageCommandValidator : AbstractValidator<SendMessageCommand>
{
    public SendMessageCommandValidator()
    {
        RuleFor(x => x.ConversationId)
            .NotEmpty();

        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.InputMessage.Input)
            .ChildRules(i => i
                .RuleFor(x => x.Text)
                .Must(t => t == null || t.Text.Length <= 1000)
                .WithMessage("Text must be less than or equal to 1000 characters"));
    }
}