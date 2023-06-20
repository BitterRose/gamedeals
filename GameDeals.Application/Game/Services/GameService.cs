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

	public async Task CreateAsync(GameDto games)
	{
		await _gameRepository.CreateAsync(new Domain.Entities.Game.Game(games.Name, new Domain.Entities.Genre.Genre(games.Genre), games.Description, games.ImageUrl, games.Price));
	}

	public async Task<GameDto> GetAsync(Guid id)
	{
		var gamesDto = await _gameRepository.GetAsync(id);
		return new GameDto(gamesDto.Name, gamesDto.Genre.Name, gamesDto.Description, gamesDto.ImageUrl, gamesDto.Price);
	}

	public async Task<IEnumerable<GameDto>> GetAsync()
	{
		var games = await _gameRepository.GetAllAsync();
		var gameDtos = new List<GameDto>();
		foreach (var game in games)
		{
			gameDtos.Add(new GameDto(game.Name, game.Genre.Name, game.Description, game.ImageUrl, game.Price));
		}
		return gameDtos;
	}

	public async Task UpdateAsync(Guid id, GameDto games)
	{
		await _gameRepository.UpdateAsync(new Domain.Entities.Game.Game(games.Name, new Domain.Entities.Genre.Genre(games.Genre), games.Description, games.ImageUrl, games.Price));
	}
}
