using ChatbotBuilderEngine.Domain.Core.Primitives;
using MediatR;

namespace ChatbotBuilderEngine.Application.Core.Abstract.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;