using ChatbotBuilderEngine.Application.Core.Extensions;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Shared.Data;

public sealed class ImageDataValidator : AbstractValidator<ImageData>
{
    public ImageDataValidator()
    {
        RuleFor(x => x.Url).IsUrl();
    }
}