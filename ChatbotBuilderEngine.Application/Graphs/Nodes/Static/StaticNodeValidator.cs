using ChatbotBuilderEngine.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderEngine.Application.Graphs.Shared.Data.Extensions;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Nodes.Static;

public sealed class StaticNodeValidator : AbstractValidator<StaticNodeDto>
{
    public StaticNodeValidator()
    {
        RuleFor(x => x.Type)
            .Must(t => t == NodeType.Static);

        RuleFor(x => x)
            .Must(x => x.DataType == x.Data.ToDataType())
            .Must(x => x.DataType == x.OutputPort.DataType);

        RuleFor(x => x.OutputPort)
            .SetValidator(new OutputPortValidator());

        RuleFor(x => x)
            .Must(x => x.OutputPort.NodeIdentifier == x.Info.Identifier);

        RuleFor(x => x.Data)
            .SetValidator(x => x.Data.GetValidator());
    }
}