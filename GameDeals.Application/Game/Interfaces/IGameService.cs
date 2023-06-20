using GameDeals.Application.Game.Models;

namespace GameDeals.Application.Game.Interfaces;
public interface IGameService
{
	Task<IEnumerable<GameDto>> GetAllAsync(bool loadPhotos);
	Task<GameDto> GetAsync(Guid id);
	Task<Guid> CreateAsync(GameDto games);
	Task UpdateAsync(GameDto games);
}
