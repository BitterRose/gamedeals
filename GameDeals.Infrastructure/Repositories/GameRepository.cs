using GameDeals.Domain.Entities.Game;
using GameDeals.Domain.Repositories;
using GameDeals.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace GameDeals.Infrastructure.Repositories;
public class GameRepository : IGameRepository
{
	private readonly ApplicationDbContext _applicationDbContext;

	public GameRepository(ApplicationDbContext applicationDbContext)
	{
		_applicationDbContext = applicationDbContext;
	}

	public async Task CreateAsync(Game game, CancellationToken cancellationToken = default)
	{
		_applicationDbContext.Games.Add(game);
		await _applicationDbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
	{
		Game? game = await _applicationDbContext.Games.FirstOrDefaultAsync(game => game.Id == id, cancellationToken);
		_applicationDbContext.Games.Remove(game);
		await _applicationDbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task<IEnumerable<Game>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		return await _applicationDbContext.Games.ToListAsync(cancellationToken);
	}

	public async Task<Game?> GetAsync(Guid id, CancellationToken cancellationToken = default)
	{
		Game? game = await _applicationDbContext.Games.FirstOrDefaultAsync(game => game.Id == id, cancellationToken);
		return game;
	}

	public async Task UpdateAsync(Game game, CancellationToken cancellationToken = default)
	{
		_applicationDbContext.Games.Update(game);
		await _applicationDbContext.SaveChangesAsync(cancellationToken);
	}
}
