using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Application.Core.Shared;

public static class CommonApplicationErrors
{
    public static class Validation
    {
        public static readonly Error CollectionContainsDuplicates = Error.ApplicationValidation(
            "Validation.CollectionContainsDuplicates",
            "Collection contains duplicates");

        public static readonly Error FieldIsNullOrEmpty = Error.ApplicationValidation(
            "Validation.FieldIsNullOrEmpty",
            "Field is null or empty");

        public static readonly Error InvalidUrl = Error.ApplicationValidation(
            "Validation.InvalidUrl",
            "Invalid URL");
    }
}