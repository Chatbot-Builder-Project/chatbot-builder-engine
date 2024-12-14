using ChatbotBuilderEngine.Domain.Core.Primitives;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatbotBuilderEngine.Persistence.Configurations.Converters;

internal sealed class EntityIdGuidConverter<TId> : ValueConverter<TId, Guid>
    where TId : EntityId<TId>
{
    public EntityIdGuidConverter()
        : base(
            id => id.Value,
            guid => (TId)Activator.CreateInstance(typeof(TId), guid)!)
    {
    }
}