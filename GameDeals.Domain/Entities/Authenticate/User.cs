using System.ComponentModel.DataAnnotations;

namespace GameDeals.Domain.Entities.Authenticate;
public class User
{
	public Guid Id { get; private set; }

	[EmailAddress, Required(ErrorMessage = "Enter your email.")]
	public string? Email { get; init; }

	[Required(ErrorMessage = "Enter password.")]
	public string? Password { get; init; }

	public Role Role { get; init; }

	public User(string email, string password, Role role)
	{
		Id = Guid.NewGuid();
		Email = email;
		Password = password;
		Role = role;
	}

	private User() { }
}