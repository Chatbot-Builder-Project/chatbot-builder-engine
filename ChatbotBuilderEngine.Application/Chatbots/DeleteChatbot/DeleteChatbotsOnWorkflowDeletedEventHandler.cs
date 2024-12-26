using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Workflows.DeleteWorkflow;
using MediatR;

namespace ChatbotBuilderEngine.Application.Chatbots.DeleteChatbot;

public sealed class DeleteChatbotsOnWorkflowDeletedEventHandler : IEventHandler<WorkflowDeletedEvent>
{
    private readonly IChatbotRepository _repository;
    private readonly IMediator _mediator;

    public DeleteChatbotsOnWorkflowDeletedEventHandler(
        IChatbotRepository repository,
        IMediator mediator)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task Handle(WorkflowDeletedEvent notification, CancellationToken cancellationToken)
    {
        var chatbotIds = await _repository.ListByWorkflowIdAsync(
            notification.WorkflowId,
            cancellationToken);

        foreach (var chatbotId in chatbotIds)
        {
            var command = new DeleteChatbotCommand
            {
                Id = chatbotId,
                OwnerId = notification.OwnerId
            };
            await _mediator.Send(command, cancellationToken);
        }
    }
}