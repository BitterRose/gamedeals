using GameDeals.Domain.Entities.Game;

namespace GameDeals.Domain.Repositories;
public interface IGenreRepository
{
	Task<IEnumerable<Genre>> GetGenresAsync();
	Task<Genre?> GetGenreAsync(Guid id);
	Task CreateGenreAsync(Genre genre);
	Task UpdateGenreAsync(Genre genre);
	Task DeleteGenreAsync(Guid id);
}
