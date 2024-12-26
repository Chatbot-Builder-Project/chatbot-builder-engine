using FluentValidation;

namespace ChatbotBuilderEngine.Application.Chatbots.GetChatbot;

public sealed class GetChatbotQueryValidator : AbstractValidator<GetChatbotQuery>
{
    public GetChatbotQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.UserId)
            .NotEmpty();
    }
}