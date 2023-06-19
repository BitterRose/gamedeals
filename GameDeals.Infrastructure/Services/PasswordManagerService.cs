using GameDeals.Domain.Services;
using Microsoft.AspNetCore.Identity;

namespace GameDeals.Infrastructure.Services;
public class PasswordManagerService : IPasswordManagerService
{
	private readonly IPasswordHasher<object> _passwordHasher;

	public PasswordManagerService(IPasswordHasher<object> passwordHasher)
	{
		_passwordHasher = passwordHasher;
	}

	public string Generate(string password)
	{
		return _passwordHasher.HashPassword(new object(), password);
	}

	public bool IsValid(string password, string securedPassword)
	{
		PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(new object(), securedPassword, password);
		return result == PasswordVerificationResult.Success;
	}
}
