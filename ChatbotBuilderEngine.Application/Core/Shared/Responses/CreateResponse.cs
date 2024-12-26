using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Application.Core.Shared.Responses;

public sealed record CreateResponse<TId>(TId Id)
    where TId : EntityId<TId>;