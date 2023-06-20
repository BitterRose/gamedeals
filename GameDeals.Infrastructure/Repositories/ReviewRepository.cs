using GameDeals.Domain.Entities.Review;
using GameDeals.Domain.Repositories;
using GameDeals.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace GameDeals.Infrastructure.Repositories;
public class ReviewRepository : IReviewRepository
{
	private readonly ApplicationDbContext _applicationDbContext;

	public ReviewRepository(ApplicationDbContext applicationDbContext)
	{
		_applicationDbContext = applicationDbContext;
	}

	public async Task CreateAsync(Review review, CancellationToken cancellationToken = default)
	{
		Review newReview = new Review(review.GameId, review.Title, review.Description, review.Rating);
		await _applicationDbContext.Reviews.AddAsync(newReview, cancellationToken);
		await _applicationDbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
	{
		Review? review = await _applicationDbContext.Reviews.FirstOrDefaultAsync(genre => genre.Id == id, cancellationToken);
		_applicationDbContext.Reviews.Remove(review);
		await _applicationDbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task<IEnumerable<Review>> GetAllByGameIdAsync(Guid gameId, CancellationToken cancellationToken = default)
	{
		return await _applicationDbContext.Reviews.Where(review => review.GameId == gameId).ToListAsync(cancellationToken);
	}

	public async Task<Review?> GetAsync(Guid id, CancellationToken cancellationToken = default)
	{
		Review? review = await _applicationDbContext.Reviews.FirstOrDefaultAsync(review => review.Id == id, cancellationToken);
		return review;
	}

	public async Task UpdateAsync(Review review, CancellationToken cancellationToken = default)
	{
		_applicationDbContext.Reviews.Update(review);
		await _applicationDbContext.SaveChangesAsync(cancellationToken);
	}
}
