using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Shared.Metas;

public sealed class VisualMetaValidator : AbstractValidator<VisualMeta>
{
    public VisualMetaValidator()
    {
    }
}