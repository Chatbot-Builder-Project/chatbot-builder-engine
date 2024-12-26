using FluentValidation;

namespace ChatbotBuilderEngine.Application.Core.Shared.Validators;

public sealed class PageParamsValidator : AbstractValidator<PageParams>
{
    public PageParamsValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page number must be greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page size must be greater than or equal to 1.");
    }
}