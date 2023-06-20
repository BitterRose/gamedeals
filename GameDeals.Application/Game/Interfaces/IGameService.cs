using GameDeals.Application.Game.Models;

namespace GameDeals.Application.Game.Interfaces;
public interface IGameService
{
	Task<IEnumerable<GameDto>> GetAsync();
	Task<GameDto> GetAsync(Guid id);
	Task CreateAsync(GameDto games);
	Task UpdateAsync(Guid id, GameDto games);
}
