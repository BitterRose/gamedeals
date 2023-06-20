using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameDeals.Application.Review.Models;
public class ReviewDto
{
	[JsonIgnore]
	public Guid ReviewId { get; set; }

	[Required]
	public Guid GameId { get; init; }

	[Required]
	public string Title { get; init; }
	public string? Description { get; init; }

	[Required]
	public int Rating { get; init; }

	public ReviewDto(Guid gameId, string title, string? description, int rating)
	{
		ReviewId = Guid.NewGuid();
		GameId = gameId;
		Title = title;
		Description = description;
		Rating = rating;
	}

	public ReviewDto() { }
}
