using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameDeals.Application.Genre.Models;
public class GenreDto
{
	[JsonIgnore]
	public Guid GenreId { get; set; }

	[Required]
	[DefaultValue("Genre")]
	public string Name { get; set; }

	public GenreDto(Guid genreId, string name)
	{
		GenreId = genreId;
		Name = name;
	}

	public GenreDto() { }
}
