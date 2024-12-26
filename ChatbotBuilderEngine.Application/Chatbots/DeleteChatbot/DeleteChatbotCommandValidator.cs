using FluentValidation;

namespace ChatbotBuilderEngine.Application.Chatbots.DeleteChatbot;

public sealed class DeleteChatbotCommandValidator : AbstractValidator<DeleteChatbotCommand>
{
    public DeleteChatbotCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.OwnerId)
            .NotEmpty();
    }
}