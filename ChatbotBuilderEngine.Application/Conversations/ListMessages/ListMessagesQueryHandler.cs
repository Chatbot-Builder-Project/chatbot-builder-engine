using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;

namespace ChatbotBuilderEngine.Application.Conversations.ListMessages;

public sealed class ListMessagesQueryHandler : IQueryHandler<ListMessagesQuery, ListMessagesResponse>
{
    private readonly IConversationRepository _repository;

    public ListMessagesQueryHandler(IConversationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ListMessagesResponse>> Handle(
        ListMessagesQuery request,
        CancellationToken cancellationToken)
    {
        var conversation = await _repository.GetByIdAndUserAsync(
            request.ConversationId,
            request.UserId,
            cancellationToken);

        if (conversation is null)
        {
            return Result<ListMessagesResponse>.Failure(ConversationsApplicationErrors.ConversationNotFound);
        }

        var response = await _repository.ListMessagesAsync(
            request.ConversationId,
            request.PageParams,
            cancellationToken);

        return Result<ListMessagesResponse>.Success(response);
    }
}