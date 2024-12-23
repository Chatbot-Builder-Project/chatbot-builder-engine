using ChatbotBuilderEngine.Application.Core.Extensions;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Shared.Metas;

public sealed class InfoMetaValidator : AbstractValidator<InfoMeta>
{
    public InfoMetaValidator()
    {
        RuleFor(x => x.Identifier)
            .GreaterThan(0);

        RuleFor(x => x.Name)
            .IsNotEmpty()
            .MaximumLength(100);
    }
}