using ChatbotBuilderEngine.Application.Core.Abstract;
using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Application.Graphs;
using ChatbotBuilderEngine.Application.Workflows;
using ChatbotBuilderEngine.Domain.Chatbots;
using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using MediatR;
using Version = ChatbotBuilderEngine.Domain.Chatbots.ValueObjects.Version;

namespace ChatbotBuilderEngine.Application.Chatbots.CreateChatbot;

public sealed class CreateChatbotCommandHandler : ICommandHandler<CreateChatbotCommand, CreateResponse<ChatbotId>>
{
    private readonly IWorkflowRepository _workflowRepository;
    private readonly IChatbotRepository _chatbotRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublisher _publisher;

    public CreateChatbotCommandHandler(
        IWorkflowRepository workflowRepository,
        IChatbotRepository chatbotRepository,
        IUnitOfWork unitOfWork,
        IPublisher publisher)
    {
        _workflowRepository = workflowRepository;
        _chatbotRepository = chatbotRepository;
        _unitOfWork = unitOfWork;
        _publisher = publisher;
    }

    public async Task<Result<CreateResponse<ChatbotId>>> Handle(
        CreateChatbotCommand request,
        CancellationToken cancellationToken)
    {
        var workflow = await _workflowRepository.GetByIdAndUserAsync(
            request.WorkflowId,
            request.OwnerId,
            includeGraph: true,
            cancellationToken);

        if (workflow is null)
        {
            return Result<CreateResponse<ChatbotId>>.Failure(ChatbotsApplicationErrors.WorkflowNotFound);
        }

        var version = await _chatbotRepository.GetLatestVersionAsync(
            request.WorkflowId,
            request.IsPublic,
            cancellationToken);

        var chatbot = Chatbot.Create(
            new ChatbotId(Guid.NewGuid()),
            workflow.Name,
            workflow.Description,
            workflow.Id,
            version ?? Version.Create(1),
            workflow.Graph.ToDto().ToDomain(), // To create a new graph
            request.IsPublic);

        _chatbotRepository.Add(chatbot);
        await _unitOfWork.CommitAsync(cancellationToken);

        var @event = new ChatbotCreatedEvent(chatbot.Id);
        await _publisher.Publish(@event, cancellationToken);

        var response = new CreateResponse<ChatbotId>(chatbot.Id);
        return Result<CreateResponse<ChatbotId>>.Success(response);
    }
}