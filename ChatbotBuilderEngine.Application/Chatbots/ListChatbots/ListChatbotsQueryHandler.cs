using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;

namespace ChatbotBuilderEngine.Application.Chatbots.ListChatbots;

public sealed class ListChatbotsQueryHandler : IQueryHandler<ListChatbotsQuery, ListChatbotsResponse>
{
    private readonly IChatbotRepository _repository;

    public ListChatbotsQueryHandler(IChatbotRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ListChatbotsResponse>> Handle(
        ListChatbotsQuery request,
        CancellationToken cancellationToken)
    {
        var chatbots = await _repository.ListByQueryAsync(request, cancellationToken);
        return Result<ListChatbotsResponse>.Success(new ListChatbotsResponse(chatbots));
    }
}