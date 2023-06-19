using GameDeals.Application.Interfaces;
using GameDeals.Domain.Entities.Authenticate;
using GameDeals.Domain.Repositories;
using GameDeals.Domain.Services;

namespace GameDeals.Application.Services;
public class AuthenticationService : IAuthenticationService
{
	private readonly IPasswordManager _passwordManager;
	private readonly IUserRepository _userRepository;

	public AuthenticationService(
		IPasswordManager passwordManager,
		IUserRepository userRepository)
	{
		_passwordManager = passwordManager;
		_userRepository = userRepository;
	}

	public async Task LoginAsync(string username, string password)
	{
		User user = await _userRepository.GetByEmailAsync(username) ?? throw new InvalidDataException("Invalid username or password");

		if (!_passwordManager.IsValid(password, user.Password))
		{
			throw new InvalidDataException("Invalid username or password");
		}
	}
}
