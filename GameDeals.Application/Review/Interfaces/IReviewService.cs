using GameDeals.Application.Review.Models;

namespace GameDeals.Application.Review.Interfaces;
public interface IReviewService
{
	Task<IEnumerable<ReviewDto>> GetAsync();
	Task<ReviewDto> GetAsync(Guid id);
	Task CreateAsync(ReviewDto reviewDto);
	Task UpdateAsync(Guid id, ReviewDto reviewDto);
	Task DeleteAsync(Guid id);
}
