using ChatbotBuilderEngine.Application.Graphs.Shared.Data;
using ChatbotBuilderEngine.Application.Graphs.Shared.Metas;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Ports.InputPorts;

public sealed class InputPortValidator : AbstractValidator<InputPortDto>
{
    public InputPortValidator()
    {
        RuleFor(x => x.Direction)
            .Must(d => d == PortDirection.Input);

        RuleFor(x => x.Info)
            .SetValidator(new InfoMetaValidator());

        RuleFor(x => x.Visual)
            .SetValidator(new VisualMetaValidator());

        RuleFor(x => x.DataType)
            .IsInEnum();
    }

    public InputPortValidator(DataType dataType) : this()
    {
        RuleFor(x => x.DataType)
            .Must(dt => dt == dataType);
    }
}