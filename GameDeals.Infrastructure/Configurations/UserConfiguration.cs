using GameDeals.Domain.Entity.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameDeals.Infrastructure.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(key => key.Id);
		builder.HasIndex(index => index.Email).IsUnique();

		builder.Property(property => property.Role)
			.IsRequired()
			.HasConversion(property => $"{property}",
			  roleEnum => Enum.Parse<Role>(roleEnum));

		builder.Property(property => property.Email)
			.IsRequired();

		builder.Property(property => property.Password)
			.IsRequired();
	}
}
