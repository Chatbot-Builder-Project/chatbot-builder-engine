using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs.Shared.Data.Extensions;

public static class DataExtensions
{
    public static DataType ToDataType(this Domain.Graphs.ValueObjects.Data.Data data)
    {
        return data switch
        {
            TextData => DataType.Text,
            OptionData => DataType.Option,
            ImageData => DataType.Image,
            _ => throw new ArgumentOutOfRangeException(nameof(data))
        };
    }

    public static AbstractValidator<TData> GetValidator<TData>(this TData data)
        where TData : Domain.Graphs.ValueObjects.Data.Data
    {
        return data switch
        {
            TextData => new TextDataValidator() as AbstractValidator<TData>,
            OptionData => new OptionDataValidator() as AbstractValidator<TData>,
            ImageData => new ImageDataValidator() as AbstractValidator<TData>,
            _ => throw new ArgumentOutOfRangeException(nameof(data))!
        };
    }
}