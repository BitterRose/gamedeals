using GameDeals.Application.Interfaces;
using GameDeals.Application.Models;
using GameDeals.Domain.Repositories;

namespace GameDeals.Application.Services;
public class UsersService : IUsersService
{
	private readonly IUserRepository _usersRepository;

	public UsersService(IUserRepository usersRepository)
	{
		_usersRepository = usersRepository;
	}

	public async Task<string> LoginAsync(LoginDto login)
	{
		return "token";
	}

	public async Task RegisterAsync(RegisterDto register)
	{
		await _usersRepository.AddAsync(register.Email, register.Password, Domain.Entities.Authenticate.Role.User);
	}
}
