using System.Text.RegularExpressions;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Domain.Core.Primitives;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Core.Extensions;

public static partial class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> rule, Error error)
    {
        return rule
            .WithErrorCode(error.Code)
            .WithMessage(error.Message);
    }

    // Not empty
    public static IRuleBuilderOptions<T, TProperty> IsNotEmpty<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .WithError(CommonApplicationErrors.Validation.FieldIsNullOrEmpty);
    }

    /// <summary>
    /// Validates that all elements in a collection are unique based on the default or provided key selector.
    /// </summary>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> IsUnique<T, TElement>(
        this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder,
        Func<TElement, object>? keySelector = null)
        where TElement : notnull
    {
        return ruleBuilder.Must(collection =>
            {
                if (collection == null)
                {
                    return true;
                }

                var seenKeys = new HashSet<object>();
                foreach (var element in collection)
                {
                    var key = keySelector != null ? keySelector(element) : element;
                    if (!seenKeys.Add(key))
                    {
                        return false;
                    }
                }

                return true;
            })
            .WithError(CommonApplicationErrors.Validation.CollectionContainsDuplicates);
    }

    /// <summary>
    /// Validates that the property is a valid URL.
    /// </summary>
    public static IRuleBuilderOptions<T, string> IsUrl<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Must(url => !string.IsNullOrWhiteSpace(url) && UrlRegex().IsMatch(url))
            .WithError(CommonApplicationErrors.Validation.InvalidUrl);
    }

    [GeneratedRegex(@"^https?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex UrlRegex();
}