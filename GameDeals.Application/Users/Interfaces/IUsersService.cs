using GameDeals.Application.Users.Models;

namespace GameDeals.Application.Users.Interfaces;
public interface IUsersService
{
	Task RegisterAsync(RegisterDto register);
	Task<string> LoginAsync(LoginDto login);
}
