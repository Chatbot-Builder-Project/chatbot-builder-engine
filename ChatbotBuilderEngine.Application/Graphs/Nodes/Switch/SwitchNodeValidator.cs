using ChatbotBuilderEngine.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderEngine.Application.Graphs.Shared.Data;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Nodes.Switch;

public sealed class SwitchNodeValidator : AbstractValidator<SwitchNodeDto>
{
    public SwitchNodeValidator()
    {
        RuleFor(x => x.Type)
            .Must(t => t == NodeType.Switch);

        RuleFor(x => x.InputPort)
            .SetValidator(new InputPortValidator(DataType.Option));

        RuleFor(x => x)
            .Must(x => x.InputPort.NodeIdentifier == x.Info.Identifier);

        RuleFor(x => x.Bindings)
            .ChildRules(b => b
                .RuleForEach(meta => meta.Keys)
                .SetValidator(new OptionDataValidator()));
    }
}