using ChatbotBuilderEngine.Application.Core.Extensions;
using ChatbotBuilderEngine.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderEngine.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderEngine.Application.Graphs.Shared.Data;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Nodes.Prompt;

public sealed class PromptNodeValidator : AbstractValidator<PromptNodeDto>
{
    public PromptNodeValidator()
    {
        RuleFor(x => x.Type)
            .Must(t => t == NodeType.Prompt);

        RuleFor(x => x.Template)
            .ChildRules(t => t
                .RuleFor(x => x.Text)
                .MaximumLength(1000));

        RuleFor(x => x.OutputPort)
            .SetValidator(new OutputPortValidator(DataType.Text));

        RuleFor(x => x)
            .Must(x => x.OutputPort.NodeIdentifier == x.Info.Identifier);

        RuleFor(x => x.InputPorts)
            .IsUnique();

        RuleForEach(x => x.InputPorts)
            .SetValidator(new InputPortValidator(DataType.Text));

        RuleFor(x => x)
            .Must(x => x.InputPorts.All(ip => ip.NodeIdentifier == x.Info.Identifier));
    }
}