using ChatbotBuilderEngine.Domain.Shared;
using MediatR;

namespace ChatbotBuilderEngine.Application.Abstract.Messaging;

/// <summary>
/// A handler for a command that does not return a response.
/// </summary>
/// <typeparam name="TCommand">A command that does not return a response</typeparam>
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>;