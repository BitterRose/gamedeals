using GameDeals.Domain.Entities.Genre;
using GameDeals.Domain.Repositories;
using GameDeals.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace GameDeals.Infrastructure.Repositories;
public class GenreRepository : IGenreRepository
{
	private readonly ApplicationDbContext _applicationDbContext;

	public GenreRepository(ApplicationDbContext applicationDbContext)
	{
		_applicationDbContext = applicationDbContext;
	}

	public async Task CreateAsync(Genre genre, CancellationToken cancellationToken = default)
	{
		_applicationDbContext.Genres.Add(genre);
		await _applicationDbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
	{
		Genre? genre = await _applicationDbContext.Genres.FirstOrDefaultAsync(genre => genre.Id == id);
		_applicationDbContext.Genres.Remove(genre);
		await _applicationDbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task<Genre?> GetAsync(Guid id, CancellationToken cancellationToken = default)
	{
		Genre? genre = await _applicationDbContext.Genres.FirstOrDefaultAsync(genre => genre.Id == id, cancellationToken);
		return genre;
	}

	public async Task<IEnumerable<Genre>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		return await _applicationDbContext.Genres.ToListAsync(cancellationToken);
	}

	public async Task UpdateAsync(Genre genre, CancellationToken cancellationToken = default)
	{
		_applicationDbContext.Genres.Update(genre);
		await _applicationDbContext.SaveChangesAsync(cancellationToken);
	}
}
