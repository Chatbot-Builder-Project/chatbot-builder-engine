namespace ChatbotBuilderEngine.DependencyInjection;

public static class PresentationServicesExtension
{
    public static void AddPresentationServices(this IServiceCollection services)
    {
        services.AddGrpc();
        services.AddGrpcReflection();
    }
}