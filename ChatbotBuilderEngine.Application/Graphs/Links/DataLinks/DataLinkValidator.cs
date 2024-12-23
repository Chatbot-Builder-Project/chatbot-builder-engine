using ChatbotBuilderEngine.Application.Graphs.Shared.Metas;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Links.DataLinks;

public sealed class DataLinkValidator : AbstractValidator<DataLinkDto>
{
    public DataLinkValidator()
    {
        RuleFor(x => x.Info)
            .SetValidator(new InfoMetaValidator());

        RuleFor(x => x.Visual)
            .SetValidator(new VisualMetaValidator());
    }
}