using ChatbotBuilderEngine.Domain.Core.Primitives;
using MediatR;

namespace ChatbotBuilderEngine.Application.Core.Abstract.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;