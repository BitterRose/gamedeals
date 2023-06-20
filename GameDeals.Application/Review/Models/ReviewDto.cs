using System.ComponentModel;
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
	[DefaultValue("Review")]
	public string Title { get; init; }

	[DefaultValue("Description")]
	public string? Description { get; init; }

	[Required]
	[Range(1, 10)]
	[DefaultValue(10)]
	public int Rating { get; init; }

	public ReviewDto(Guid gameId, string title, string? description, int rating)
	{
		ReviewId = Guid.NewGuid();
		GameId = gameId;
		Title = title;
		Description = description;
		Rating = rating;
	}

	public ReviewDto(Guid id, Guid gameId, string title, string? description, int rating)
	{
		ReviewId = id;
		GameId = gameId;
		Title = title;
		Description = description;
		Rating = rating;
	}

	public ReviewDto() { }
}
