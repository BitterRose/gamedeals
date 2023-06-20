using GameDeals.Domain.Entities.Genre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameDeals.Infrastructure.Configurations;
public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
	public void Configure(EntityTypeBuilder<Genre> builder)
	{
		builder.HasKey(key => key.Id);

		builder.Property(property => property.Name)
			.IsRequired();
	}
}