using ChatbotBuilderEngine.Infrastructure.PipelineBehaviors;
using MediatR;

namespace ChatbotBuilderEngine.DependencyInjection;

public static class InfrastructureServicesExtension
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}