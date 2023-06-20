using GameDeals.Application.Review.Models;

namespace GameDeals.Application.Review.Interfaces;
public interface IReviewService
{
	Task<IEnumerable<ReviewDto>> GetAllByGameIdAsync(Guid gameId);
	Task<ReviewDto> GetByIdAsync(Guid id);
	Task<Guid> CreateAsync(ReviewDto reviewDto);
	Task UpdateAsync(Guid id, ReviewDto reviewDto);
	Task DeleteAsync(Guid id);
}
