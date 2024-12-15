using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Domain.Users;

public sealed class UserId : EntityId<UserId>
{
    public UserId(Guid value) : base(value)
    {
    }
}