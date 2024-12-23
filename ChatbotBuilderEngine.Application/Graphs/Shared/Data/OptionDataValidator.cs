using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Shared.Data;

public sealed class OptionDataValidator : AbstractValidator<OptionData>
{
    public OptionDataValidator()
    {
    }
}