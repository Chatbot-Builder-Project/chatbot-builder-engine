using ChatbotBuilderEngine.Application.Core.Shared.Validators;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Workflows.ListWorkflows;

public sealed class ListWorkflowsQueryValidator : AbstractValidator<ListWorkflowsQuery>
{
    public ListWorkflowsQueryValidator()
    {
        RuleFor(x => x.OwnerId)
            .NotEmpty();

        RuleFor(x => x.Search)
            .MaximumLength(100);

        RuleFor(x => x.PageParams)
            .SetValidator(new PageParamsValidator());
    }
}