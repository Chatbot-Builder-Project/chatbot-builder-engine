using FluentValidation;

namespace ChatbotBuilderEngine.Application.Chatbots.UpdateChatbot;

public sealed class UpdateChatbotCommandValidator : AbstractValidator<UpdateChatbotCommand>
{
    public UpdateChatbotCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(1000);
    }
}