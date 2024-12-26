using ChatbotBuilderEngine.Application.Graphs;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Workflows.CreateWorkflow;

public sealed class CreateWorkflowCommandValidator : AbstractValidator<CreateWorkflowCommand>
{
    public CreateWorkflowCommandValidator()
    {
        RuleFor(x => x.OwnerId)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.Graph)
            .SetValidator(new GraphValidator());
    }
}