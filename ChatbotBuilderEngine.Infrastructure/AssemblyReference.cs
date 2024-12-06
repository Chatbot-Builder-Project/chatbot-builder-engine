using System.Reflection;

namespace ChatbotBuilderEngine.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}