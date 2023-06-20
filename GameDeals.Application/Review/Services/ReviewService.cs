using GameDeals.Application.Review.Interfaces;
using GameDeals.Application.Review.Models;
using GameDeals.Domain.Repositories;

namespace GameDeals.Application.Review.Services;
public class ReviewService : IReviewService
{
	private readonly IReviewRepository _reviewRepository;
	public ReviewService(IReviewRepository reviewRepository)
	{
		_reviewRepository = reviewRepository;
	}

	public async Task CreateAsync(ReviewDto reviewDto)
	{
		await _reviewRepository.CreateAsync(new Domain.Entities.Review.Review(reviewDto.GameId, reviewDto.Title, reviewDto.Description, reviewDto.Rating));
	}

	public async Task DeleteAsync(Guid id)
	{
		await _reviewRepository.DeleteAsync(id);
	}

	public async Task<ReviewDto> GetAsync(Guid id)
	{
		var reviewDto = await _reviewRepository.GetAsync(id);
		return new ReviewDto(reviewDto.GameId, reviewDto.Title, reviewDto.Description, reviewDto.Rating);
	}

	public async Task<IEnumerable<ReviewDto>> GetAsync()
	{
		var reviews = await _reviewRepository.GetAllAsync();
		var reviewDtos = new List<ReviewDto>();
		foreach (var review in reviews)
		{
			reviewDtos.Add(new ReviewDto(review.GameId, review.Title, review.Description, review.Rating));
		}
		return reviewDtos;
	}

	public async Task UpdateAsync(Guid id, ReviewDto reviewDto)
	{
		await _reviewRepository.UpdateAsync(new Domain.Entities.Review.Review(reviewDto.GameId, reviewDto.Title, reviewDto.Description, reviewDto.Rating));
	}


}
