using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;

namespace ChatbotBuilderEngine.Application.Conversations.ListConversations;

public sealed class ListConversationsQueryHandler : IQueryHandler<ListConversationsQuery, ListConversationsResponse>
{
    private readonly IConversationRepository _repository;

    public ListConversationsQueryHandler(IConversationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ListConversationsResponse>> Handle(
        ListConversationsQuery request,
        CancellationToken cancellationToken)
    {
        var conversations = await _repository.ListByQueryAsync(request, cancellationToken);
        var response = new ListConversationsResponse(conversations);
        return Result<ListConversationsResponse>.Success(response);
    }
}