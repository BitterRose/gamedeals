using GameDeals.Application.Genre.Interfaces;
using GameDeals.Application.Genre.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameDeals.Api.Controllers;

[ApiController]
[Route("api/genre/")]
public class GenreController : ControllerBase
{
	private readonly IGenreService _genreService;

	public GenreController(IGenreService genreService)
	{
		_genreService = genreService;
	}

	[HttpGet]
	[Authorize("AnyRole")]
	public async Task<IActionResult> GetAllGenre()
	{
		var genres = await _genreService.GetGenresAsync();
		return Ok(genres);
	}

	[HttpGet("{id}")]
	[Authorize("AnyRole")]
	public async Task<IActionResult> GetByIdGenre(Guid id)
	{
		var genre = await _genreService.GetGenreAsync(id);
		if (genre is null)
			return NotFound();

		return Ok(genre);
	}

	[HttpDelete("{id}")]
	[Authorize("AdminRole")]
	public async Task<IActionResult> DeleteGenre(Guid id)
	{
		await _genreService.DeleteGenreAsync(id);
		return NoContent();
	}

	[HttpPost]
	[Authorize("AdminRole")]
	public async Task<IActionResult> CreateGenre([FromBody] GenreDto genreDto)
	{
		if (genreDto is null)
			return BadRequest();

		await _genreService.CreateGenreAsync(genreDto);
		return CreatedAtAction(nameof(CreateGenre), genreDto);
	}

	[HttpPut("{id}")]
	[Authorize("AdminRole")]
	public async Task<IActionResult> UpdateGenre(Guid id, [FromBody] GenreDto genreDto)
	{
		if (genreDto is null)
			return BadRequest();

		await _genreService.UpdateGenreAsync(id, genreDto);
		return Ok();
	}
}