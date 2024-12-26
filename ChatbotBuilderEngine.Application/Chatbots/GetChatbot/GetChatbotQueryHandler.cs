using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;

namespace ChatbotBuilderEngine.Application.Chatbots.GetChatbot;

public sealed class GetChatbotQueryHandler : IQueryHandler<GetChatbotQuery, GetChatbotResponse>
{
    private readonly IChatbotRepository _repository;

    public GetChatbotQueryHandler(IChatbotRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetChatbotResponse>> Handle(GetChatbotQuery request, CancellationToken cancellationToken)
    {
        var chatbot = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (chatbot is null)
        {
            return Result<GetChatbotResponse>.Failure(ChatbotsApplicationErrors.ChatbotNotFound);
        }

        var ownerId = (await _repository.GetOwnerIdAsync(request.Id, cancellationToken))!;

        GetChatbotResponseAdminDetails? adminDetails = null;
        if (request.UserId == ownerId)
        {
            var latestVersion = await _repository.GetLatestVersionAsync(
                chatbot.WorkflowId,
                chatbot.IsPublic,
                cancellationToken);

            adminDetails = new GetChatbotResponseAdminDetails(
                chatbot.Version,
                chatbot.WorkflowId,
                chatbot.IsPublic,
                chatbot.Version == latestVersion);
        }

        var response = new GetChatbotResponse(
            chatbot.Id,
            ownerId,
            chatbot.CreatedAt,
            chatbot.UpdatedAt,
            chatbot.Name,
            chatbot.Description,
            adminDetails);

        return Result<GetChatbotResponse>.Success(response);
    }
}