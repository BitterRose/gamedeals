using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameDeals.Application.Game.Models;
public class GameDto
{
	[JsonIgnore]
	public Guid GameId { get; set; }

	[Required]
	[DefaultValue("GameName")]
	public string Name { get; set; }

	[Required]
	[DefaultValue("GameGenre")]
	public string Genre { get; init; }

	[Required]
	[DefaultValue("GameDescription")]
	public string Description { get; init; }

	[DefaultValue(null)]
	public byte[]? ImageUrl { get; init; }

	[Required]
	[DefaultValue(10)]
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

	public GameDto(Guid gameId, string name, string genre, string description, byte[]? imageUrl, decimal price)
	{
		GameId = gameId;
		Name = name;
		Genre = genre;
		Description = description;
		ImageUrl = imageUrl;
		Price = price;
	}

	public GameDto() { }
}
