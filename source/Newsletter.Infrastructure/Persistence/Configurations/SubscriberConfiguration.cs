using Microsoft.EntityFrameworkCore;
using Newsletter.Domain.Entities;
using Newsletter.Domain.Types;

namespace Newsletter.Infrastructure.Persistence.Configurations;

public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Subscriber> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            subscriberId => subscriberId.Value,
            value => new SubscriberId(value));

        builder.Property(c => c.Email).HasMaxLength(255);
        builder.Property(c => c.FirstName).HasMaxLength(255);
        builder.Property(c => c.LastName).HasMaxLength(255);
    }
}
