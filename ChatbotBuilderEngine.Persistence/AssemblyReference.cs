using System.Reflection;

namespace ChatbotBuilderEngine.Persistence;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}