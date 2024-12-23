using ChatbotBuilderEngine.Application.Graphs.Shared.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Interactions;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Shared.Interactions;

public sealed class InteractionInputValidator : AbstractValidator<InteractionInput>
{
    public InteractionInputValidator()
    {
        RuleFor(x => x.Text)
            .SetValidator(new TextDataValidator()!)
            .When(x => x.Text is not null);

        RuleFor(x => x.Option)
            .SetValidator(new OptionDataValidator()!)
            .When(x => x.Option is not null);
    }
}