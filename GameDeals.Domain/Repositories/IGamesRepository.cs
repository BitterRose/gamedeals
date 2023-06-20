using GameDeals.Domain.Entities.Game;

namespace GameDeals.Domain.Repositories;
public interface IGamesRepository
{
	Task<IEnumerable<Game>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<Game?> GetAsync(Guid id, CancellationToken cancellationToken = default);
	Task CreateAsync(Game game, CancellationToken cancellationToken = default);
	Task UpdateAsync(Game game, CancellationToken cancellationToken = default);
	Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
