using GameDeals.Domain.Entities.Genre;

namespace GameDeals.Domain.Repositories;
public interface IGenreRepository
{
	Task<IEnumerable<Genre>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<Genre?> GetAsync(Guid id, CancellationToken cancellationToken = default);
	Task CreateAsync(Genre genre, CancellationToken cancellationToken = default);
	Task UpdateAsync(Genre genre, CancellationToken cancellationToken = default);
	Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
