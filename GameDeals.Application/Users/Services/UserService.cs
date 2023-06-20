using GameDeals.Application.Users.Interfaces;
using GameDeals.Application.Users.Models;
using GameDeals.Domain.Entities.Authenticate;
using GameDeals.Domain.Repositories;
using GameDeals.Domain.Services;

namespace GameDeals.Application.Users.Services;
public class UserService : IUserService
{
	private readonly IPasswordManagerService _passwordManager;
	private readonly IUserRepository _userRepository;
	private readonly IJwtService _jwtService;

	public UserService(
		IPasswordManagerService passwordManager,
		IUserRepository usersRepository,
		IJwtService jwtService)
	{
		_passwordManager = passwordManager;
		_userRepository = usersRepository;
		_jwtService = jwtService;
	}

	public async Task<string> LoginAsync(LoginDto login)
	{
		User user = await _userRepository.GetByEmailAsync(login.Email) ?? throw new InvalidDataException("Invalid username or password");

		if (!_passwordManager.IsValid(login.Password, user.Password))
			throw new InvalidDataException("Invalid username or password");

		return _jwtService.GenerateToken(user.Id, user.Email, $"{user.Role}");
	}

	public async Task RegisterAsync(RegisterDto register)
	{
		await _userRepository.AddAsync(register.Email, _passwordManager.Generate(register.Password), Role.User);
	}
}
