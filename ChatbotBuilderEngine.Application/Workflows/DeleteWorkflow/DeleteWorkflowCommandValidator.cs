using FluentValidation;

namespace ChatbotBuilderEngine.Application.Workflows.DeleteWorkflow;

public sealed class DeleteWorkflowCommandValidator : AbstractValidator<DeleteWorkflowCommand>
{
    public DeleteWorkflowCommandValidator()
    {
        RuleFor(x => x.OwnerId)
            .NotEmpty();
    }
}