using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Interactions;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Shared.Interactions;

public sealed class InteractionOptionMetaValidator : AbstractValidator<InteractionOptionMeta>
{
    public InteractionOptionMetaValidator()
    {
        RuleFor(x => x.Description)
            .MaximumLength(1000);
    }
}