using GameDeals.Application.Game.Interfaces;
using GameDeals.Application.Game.Models;
using GameDeals.Domain.Repositories;

namespace GameDeals.Application.Game.Services;
public class GameService : IGameService
{
	private readonly IGameRepository _gameRepository;
	public GameService(IGameRepository gameRepository)
	{
		_gameRepository = gameRepository;
	}

	public async Task<Guid> CreateAsync(GameDto gameDto)
	{
		var game = new Domain.Entities.Game.Game(gameDto.Name, new Domain.Entities.Genre.Genre(gameDto.Genre), gameDto.Description, gameDto.ImageUrl, gameDto.Price);
		await _gameRepository.CreateAsync(game);
		return game.Id;
	}

	public async Task<GameDto> GetAsync(Guid id)
	{
		var game = await _gameRepository.GetAsync(id);
		var gameDto = new GameDto(game.Id, game.Name, game.Genre.Name, game.Description, game.ImageUrl, game.Price);
		return gameDto;
	}

	public async Task<IEnumerable<GameDto>> GetAllAsync(bool loadPhotos)
	{
		var games = await _gameRepository.GetAllAsync();
		var gameDtos = new List<GameDto>();
		foreach (var game in games)
		{
			gameDtos.Add(new GameDto(game.Id, game.Name, game.Genre.Name, game.Description, loadPhotos ? game.ImageUrl : null, game.Price));
		}
		return gameDtos;
	}

	public async Task UpdateAsync(GameDto gameDto)
	{
		await _gameRepository.UpdateAsync(new Domain.Entities.Game.Game(gameDto.GameId, gameDto.Name, new Domain.Entities.Genre.Genre(gameDto.Genre), gameDto.Description, gameDto.ImageUrl, gameDto.Price));
	}
}
