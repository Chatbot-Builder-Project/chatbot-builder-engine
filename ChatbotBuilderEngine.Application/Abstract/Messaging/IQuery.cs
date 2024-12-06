using ChatbotBuilderEngine.Domain.Shared;
using MediatR;

namespace ChatbotBuilderEngine.Application.Abstract.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;