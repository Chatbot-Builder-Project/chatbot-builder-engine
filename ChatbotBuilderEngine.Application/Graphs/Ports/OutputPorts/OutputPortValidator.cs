using ChatbotBuilderEngine.Application.Graphs.Shared.Data;
using ChatbotBuilderEngine.Application.Graphs.Shared.Metas;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Ports.OutputPorts;

public sealed class OutputPortValidator : AbstractValidator<OutputPortDto>
{
    public OutputPortValidator()
    {
        RuleFor(x => x.Direction)
            .Must(d => d == PortDirection.Output);

        RuleFor(x => x.Info)
            .SetValidator(new InfoMetaValidator());

        RuleFor(x => x.Visual)
            .SetValidator(new VisualMetaValidator());

        RuleFor(x => x.DataType)
            .IsInEnum();
    }

    public OutputPortValidator(DataType dataType) : this()
    {
        RuleFor(x => x.DataType)
            .Must(dt => dt == dataType);
    }
}