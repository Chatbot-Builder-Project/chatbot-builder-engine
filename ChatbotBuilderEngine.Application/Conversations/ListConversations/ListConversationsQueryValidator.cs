using ChatbotBuilderEngine.Application.Core.Shared.Validators;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Conversations.ListConversations;

public sealed class ListConversationsQueryValidator : AbstractValidator<ListConversationsQuery>
{
    public ListConversationsQueryValidator()
    {
        RuleFor(x => x.PageParams)
            .SetValidator(new PageParamsValidator());

        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.Search)
            .MaximumLength(100);
    }
}