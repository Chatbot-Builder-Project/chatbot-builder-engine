using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatbotBuilderEngine.Persistence.Configurations.Converters;

/// <remarks>
/// When serializing a dictionary, update operations on the dictionary will not be tracked by EF Core.
/// So you would need to call <see cref="DbContext.Update{TEntity}(TEntity)"/> explicitly on the entity.
/// </remarks>
public class DictionaryJsonConverter<TKey, TValue> : ValueConverter<Dictionary<TKey, TValue>, string>
    where TKey : notnull
{
    public DictionaryJsonConverter() : base(
        dict => JsonSerializer.Serialize(dict, new JsonSerializerOptions { WriteIndented = false }),
        json => JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(json, new JsonSerializerOptions()) ??
                new Dictionary<TKey, TValue>())
    {
    }
}

public class NullableDictionaryJsonConverter<TKey, TValue> : ValueConverter<Dictionary<TKey, TValue>?, string>
    where TKey : notnull

{
    public NullableDictionaryJsonConverter() : base(
        dict => dict == null
            ? null!
            : JsonSerializer.Serialize(dict, new JsonSerializerOptions { WriteIndented = false }),
        json => string.IsNullOrEmpty(json)
            ? null
            : JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(json, new JsonSerializerOptions()))
    {
    }
}