using GameDeals.Application.Models;

namespace GameDeals.Application.Interfaces;
public interface IUsersService
{
	Task RegisterAsync(RegisterDto register);
	Task<string> LoginAsync(LoginDto login);
}
