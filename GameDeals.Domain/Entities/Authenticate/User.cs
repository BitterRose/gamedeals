using System.ComponentModel.DataAnnotations;

namespace GameDeals.Domain.Entity.Auth;
public class User
{
	public Guid Id { get; } = Guid.NewGuid();

	[Required(ErrorMessage = "Enter a username.")]
	public string? UserName { get; init; }

	[Required(ErrorMessage = "Enter password.")]
	public string? Password { get; init; }

	[EmailAddress, Required(ErrorMessage = "Enter your email.")]
	public string? Email { get; init; }

	public Role Role { get; init; }

	public User(string userName, string password, string email, Role role)
	{
		UserName = userName;
		Password = password;
		Email = email;
		Role = role;
	}

	private User() { }
}