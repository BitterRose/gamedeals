using GameDeals.Application.Genre.Interfaces;
using GameDeals.Application.Genre.Models;
using GameDeals.Application.Review.Interfaces;
using GameDeals.Application.Review.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameDeals.Api.Controllers;

[ApiController]
[Authorize("AnyRole")]
[Route("api/review/")]
public class ReviewController : ControllerBase
{
	private readonly IReviewService _reviewService;

	public ReviewController(IReviewService reviewService)
	{
		_reviewService = reviewService;
	}

	[HttpGet("{gameId}/reviews")]
	public async Task<IActionResult> GetAllReviewByGameId(Guid gameId)
	{
		var genres = await _reviewService.GetAllByGameIdAsync(gameId);
		var response = genres.Select(x =>
		new {

			x.ReviewId,
			x.GameId,
			x.Rating,
			x.Description,
			x.Title
		});
		return Ok(response);
	}

	[HttpGet("{id}")]
	[Authorize("AnyRole")]
	public async Task<IActionResult> GetByReviewId(Guid id)
	{
		var genre = await _reviewService.GetByIdAsync(id);
		if (genre is null)
			return NotFound();

		return Ok(genre);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteReview(Guid id)
	{
		await _reviewService.DeleteAsync(id);
		return NoContent();
	}

	[HttpPost]
	public async Task<IActionResult> CreateReview([FromBody] ReviewDto reviewDto)
	{
		if (reviewDto is null)
			return BadRequest();

		Guid id = await _reviewService.CreateAsync(reviewDto);
		return CreatedAtAction(nameof(CreateReview), new
		{
			id = id,
			reviewDto.GameId,
			reviewDto.Rating,
			reviewDto.Description,
			reviewDto.Title
		});
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateReview(Guid id, [FromBody] ReviewDto reviewDto)
	{
		if (reviewDto is null)
			return BadRequest();

		await _reviewService.UpdateAsync(id, reviewDto);
		return Ok();
	}
}