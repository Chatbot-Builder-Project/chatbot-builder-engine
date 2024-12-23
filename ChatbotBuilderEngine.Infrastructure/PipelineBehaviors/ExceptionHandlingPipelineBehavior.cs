using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Core.Primitives;
using FluentValidation;
using MediatR;

namespace ChatbotBuilderEngine.Infrastructure.PipelineBehaviors;

public class ExceptionHandlingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (ValidationException ex)
        {
            var validationErrors = ex.Errors
                .Select(error => new ValidationError(error.PropertyName, error.ErrorMessage))
                .ToList();

            var validationResult = typeof(TResponse).IsGenericType
                ? (TResponse)Activator.CreateInstance(
                    typeof(Result<>).MakeGenericType(typeof(TResponse).GetGenericArguments()[0]),
                    null,
                    false,
                    Error.ApplicationValidation("Validation.Failed", ex.Message),
                    validationErrors)!
                : (TResponse)Result.ValidationFailure(
                    "Validation.Failed",
                    ex.Message,
                    validationErrors);

            return validationResult;
        }
        catch (DomainException ex)
        {
            var domainResult = typeof(TResponse).IsGenericType
                ? (TResponse)Activator.CreateInstance(
                    typeof(Result<>).MakeGenericType(typeof(TResponse).GetGenericArguments()[0]),
                    null,
                    false,
                    ex.Error,
                    Array.Empty<ValidationError>())!
                : (TResponse)Result.Failure(ex.Error);

            return domainResult;
        }
    }
}