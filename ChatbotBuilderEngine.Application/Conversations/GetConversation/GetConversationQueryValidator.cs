using FluentValidation;

namespace ChatbotBuilderEngine.Application.Conversations.GetConversation;

public sealed class GetConversationQueryValidator : AbstractValidator<GetConversationQuery>
{
    public GetConversationQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.UserId)
            .NotEmpty();
    }
}