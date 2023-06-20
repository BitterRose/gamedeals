using GameDeals.Domain.Entities.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameDeals.Infrastructure.Configurations;
public class GameConfiguration : IEntityTypeConfiguration<Game>
{
	public void Configure(EntityTypeBuilder<Game> builder)
	{
		builder.HasKey(key => key.Id);

		builder.Property(property => property.Genre)
			.IsRequired()
			.HasConversion(property => property.Name,
			  genre => new Genre(genre));

		builder.Property(property => property.Name)
			.IsRequired();

		builder.Property(property => property.Description)
			.IsRequired();

		builder.Property(property => property.Price)
			.IsRequired();

		builder.Property(property => property.ImageUrl)
			.HasConversion(builder => Convert.ToBase64String(builder),
						  builder => Convert.FromBase64String(builder));

		builder.HasMany(property => property.Reviews)
			.WithOne(property => property.Game)
			.HasForeignKey(key => key.GameId)
			.IsRequired();
	}
}
