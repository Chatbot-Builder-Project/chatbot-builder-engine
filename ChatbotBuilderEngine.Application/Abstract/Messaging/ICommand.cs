using ChatbotBuilderEngine.Domain.Shared;
using MediatR;

namespace ChatbotBuilderEngine.Application.Abstract.Messaging;

/// <summary>
/// A command that does not return response.
/// </summary>
public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;