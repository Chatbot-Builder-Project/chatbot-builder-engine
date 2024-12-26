using ChatbotBuilderEngine.Application.Chatbots.DeleteChatbot;
using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using MediatR;

namespace ChatbotBuilderEngine.Application.Conversations.DeleteConversation;

public sealed class DeleteConversationsOnChatbotDeletedEventHandler : IEventHandler<ChatbotDeletedEvent>
{
    private readonly IConversationRepository _repository;
    private readonly IMediator _mediator;

    public DeleteConversationsOnChatbotDeletedEventHandler(
        IConversationRepository repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task Handle(ChatbotDeletedEvent notification, CancellationToken cancellationToken)
    {
        var conversationIds = await _repository.ListByChatbotIdAsync(
            notification.ChatbotId,
            cancellationToken);

        foreach (var conversationId in conversationIds)
        {
            var command = new DeleteConversationCommand
            {
                Id = conversationId,
                OwnerId = notification.OwnerId
            };
            await _mediator.Send(command, cancellationToken);
        }
    }
}