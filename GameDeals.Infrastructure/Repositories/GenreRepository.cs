using GameDeals.Domain.Entities.Game;
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

	public async Task CreateGenreAsync(Genre genre)
	{
		_applicationDbContext.Genres.Add(genre);
		await _applicationDbContext.SaveChangesAsync();
	}

	public async Task DeleteGenreAsync(Guid id)
	{
		Genre? genre = await _applicationDbContext.Genres.FirstOrDefaultAsync(genre => genre.Id == id);
		_applicationDbContext.Genres.Remove(genre);
		await _applicationDbContext.SaveChangesAsync();
	}

	public async Task<Genre?> GetGenreAsync(Guid id)
	{
		Genre? genre = await _applicationDbContext.Genres.FirstOrDefaultAsync(genre => genre.Id == id);
		return genre;
	}

	public async Task<IEnumerable<Genre>> GetGenresAsync()
	{
		return await _applicationDbContext.Genres.ToListAsync();
	}

	public async Task UpdateGenreAsync(Genre genre)
	{
		_applicationDbContext.Genres.Update(genre);
		await _applicationDbContext.SaveChangesAsync();
	}
}
