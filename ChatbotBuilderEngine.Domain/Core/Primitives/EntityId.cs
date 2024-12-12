namespace ChatbotBuilderEngine.Domain.Core.Primitives;

public abstract class EntityId<TSelf> : ValueObject where TSelf : EntityId<TSelf>
{
    public Guid Value { get; }

    protected EntityId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("The ID value cannot be an empty GUID.", nameof(value));
        }

        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();

    public static implicit operator Guid(EntityId<TSelf> entityId) => entityId.Value;
}