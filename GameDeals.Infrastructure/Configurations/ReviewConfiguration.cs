using GameDeals.Domain.Entities.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameDeals.Infrastructure.Configurations;
public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
	public void Configure(EntityTypeBuilder<Review> builder)
	{

		builder.HasKey(key => key.Id);

		builder.Property(property => property.Id)
			.IsRequired();

		builder.Property(property => property.GameId)
			.IsRequired();

		builder.Property(property => property.Title)
			.IsRequired();

		builder.Property(property => property.Rating)
			.IsRequired();

		builder.HasOne(e => e.Game)
			.WithMany(e => e.Reviews)
			.HasForeignKey(e => e.GameId)
			.IsRequired();
	}
}