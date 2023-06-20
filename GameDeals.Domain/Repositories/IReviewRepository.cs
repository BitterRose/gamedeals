using GameDeals.Domain.Entities.Review;

namespace GameDeals.Domain.Repositories;
public interface IReviewRepository
{
	Task<IEnumerable<Review>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<Review?> GetAsync(Guid id, CancellationToken cancellationToken = default);
	Task CreateAsync(Review review, CancellationToken cancellationToken = default);
	Task UpdateAsync(Review review, CancellationToken cancellationToken = default);
	Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
