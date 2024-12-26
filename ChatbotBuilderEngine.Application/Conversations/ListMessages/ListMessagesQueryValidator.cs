using ChatbotBuilderEngine.Application.Core.Shared.Validators;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Conversations.ListMessages;

public sealed class ListMessagesQueryValidator : AbstractValidator<ListMessagesQuery>
{
    public ListMessagesQueryValidator()
    {
        RuleFor(x => x.ConversationId)
            .NotEmpty();

        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.PageParams)
            .SetValidator(new PageParamsValidator());
    }
}