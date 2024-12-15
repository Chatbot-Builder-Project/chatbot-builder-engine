using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderEngine.Persistence.Configurations.Users;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ConfigureAggregateRoot();

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ApplyEntityIdConversion();
    }
}