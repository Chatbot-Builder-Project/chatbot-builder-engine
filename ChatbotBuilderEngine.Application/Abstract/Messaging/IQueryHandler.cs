using ChatbotBuilderEngine.Domain.Shared;
using MediatR;

namespace ChatbotBuilderEngine.Application.Abstract.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;