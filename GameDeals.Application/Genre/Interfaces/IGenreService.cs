using GameDeals.Application.Genre.Models;

namespace GameDeals.Application.Genre.Interfaces;
public interface IGenreService
{
	Task<IEnumerable<GenreDto>> GetGenresAsync();
	Task<GenreDto> GetGenreAsync(Guid id);
	Task CreateGenreAsync(GenreDto genre);
	Task UpdateGenreAsync(Guid id, GenreDto genre);
	Task DeleteGenreAsync(Guid id);

}
