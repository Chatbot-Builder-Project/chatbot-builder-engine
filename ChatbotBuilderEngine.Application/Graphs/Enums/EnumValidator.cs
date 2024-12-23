using ChatbotBuilderEngine.Application.Core.Extensions;
using ChatbotBuilderEngine.Application.Graphs.Shared.Data;
using ChatbotBuilderEngine.Application.Graphs.Shared.Metas;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Enums;

public sealed class EnumValidator : AbstractValidator<EnumDto>
{
    public EnumValidator()
    {
        RuleFor(x => x.Info)
            .SetValidator(new InfoMetaValidator());

        RuleFor(x => x.Options)
            .IsNotEmpty()
            .IsUnique();

        RuleForEach(x => x.Options)
            .SetValidator(new OptionDataValidator());
    }
}