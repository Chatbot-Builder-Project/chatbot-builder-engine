using ChatbotBuilderEngine.Domain.Core.Primitives;
using MediatR;

namespace ChatbotBuilderEngine.Application.Core.Abstract.Messaging;

/// <summary>
/// A command that does not return response.
/// </summary>
public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;