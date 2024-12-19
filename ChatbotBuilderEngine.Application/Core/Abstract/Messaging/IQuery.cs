using ChatbotBuilderEngine.Application.Core.Shared;
using MediatR;

namespace ChatbotBuilderEngine.Application.Core.Abstract.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;