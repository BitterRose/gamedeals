using System.ComponentModel.DataAnnotations;

namespace GameDeals.Domain.Entities.Authenticate;
public class RegisterDto
{
	[EmailAddress]
	[Required(ErrorMessage = "Enter your email.")]
	[DataType(DataType.EmailAddress)]
	public string Email { get; init; }

	[Required(ErrorMessage = "Enter password.")]
	[DataType(DataType.Password)]
	public string Password { get; init; }

	[Required(ErrorMessage = "Enter confirmation password.")]
	[DataType(DataType.Password)]
	public string ConfirmPassword { get; init; }

	public RegisterDto(string email, string password, string confirmPassword)
	{
		Email = email;
		Password = password;
		ConfirmPassword = confirmPassword;
	}
}