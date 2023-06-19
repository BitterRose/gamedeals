using System.ComponentModel.DataAnnotations;

namespace GameDeals.Application.Models;
public class LoginDto
{
	[EmailAddress]
	[Required(ErrorMessage = "Enter your email.")]
	[DataType(DataType.EmailAddress)]
	public string Email { get; init; }

	[Required(ErrorMessage = "Enter password.")]
	[DataType(DataType.Password)]
	public string Password { get; init; }

	public LoginDto(string email, string password)
	{
		Email = email;
		Password = password;
	}
}