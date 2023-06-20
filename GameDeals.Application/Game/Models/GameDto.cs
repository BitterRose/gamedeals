using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameDeals.Application.Game.Models;
public class GameDto
{
	[JsonIgnore]
	public Guid GameId { get; set; }

	[Required]
	public string Name { get; set; }

	[Required]
	public string Genre { get; init; }

	[Required]
	public string Description { get; init; }
	public byte[]? ImageUrl { get; init; }

	[Required]
	public decimal Price { get; init; }

	public GameDto(string name, string genre, string description, byte[]? imageUrl, decimal price)
	{
		GameId = Guid.NewGuid();
		Name = name;
		Genre = genre;
		Description = description;
		ImageUrl = imageUrl;
		Price = price;
	}

	public GameDto() { }
}
