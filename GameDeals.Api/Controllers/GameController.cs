using GameDeals.Application.Game.Interfaces;
using GameDeals.Application.Game.Models;
using GameDeals.Application.Genre.Interfaces;
using GameDeals.Application.Genre.Models;
using GameDeals.Domain.Entities.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameDeals.Api.Controllers;

[ApiController]
[Route("api/game/")]
public class GameController : ControllerBase
{
	private readonly IGameService _gameService;

	public GameController(IGameService gameService)
	{
		_gameService = gameService;
	}

	[HttpGet]
	[Authorize("AnyRole")]
	public async Task<IActionResult> GetAllGames([Required][FromQuery][DefaultValue(false)] bool loadPhotos)
	{
		var games = await _gameService.GetAllAsync(loadPhotos);
		var response = games.Select(x => new
		{
			id = x.GameId,
			x.Name,
			x.Genre,
			x.Description,
			x.ImageUrl,
			x.Price,			
		});
		return Ok(response);
	}

	[HttpGet("{id}")]
	[Authorize("AnyRole")]
	public async Task<IActionResult> GetByIdGame(Guid id)
	{
		var game = await _gameService.GetAsync(id);
		if (game is null)
			return NotFound();

		return Ok(new { 
			id = game.GameId, 
			game.Name,
			game.Genre,
			game.Description,
			game.ImageUrl,
			game.Price,
		});
	}

	[HttpPost]
	[Authorize("AdminRole")]
	public async Task<IActionResult> CreateGame([FromBody] GameDto gameDto)
	{
		if (gameDto is null)
			return BadRequest();

		Guid id = await _gameService.CreateAsync(gameDto);
		return CreatedAtAction(nameof(CreateGame), new { id, gameDto });
	}

	[HttpPut("{id}")]
	[Authorize("AdminRole")]
	public async Task<IActionResult> UpdateGame(Guid id, [FromBody] GameDto gameDto)
	{
		if (gameDto is null)
			return BadRequest();

		await _gameService.UpdateAsync( new GameDto(id, gameDto.Name, gameDto.Genre, gameDto.Description, gameDto.ImageUrl, gameDto.Price));
		return Ok();
	}
}