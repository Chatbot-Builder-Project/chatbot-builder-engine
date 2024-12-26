using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;

namespace ChatbotBuilderEngine.Application.Conversations.ListMessages;

public sealed record ListMessagesResponse(
    PageResponse<InputMessage> InputMessagesPage,
    PageResponse<OutputMessage> OutputMessagesPage);