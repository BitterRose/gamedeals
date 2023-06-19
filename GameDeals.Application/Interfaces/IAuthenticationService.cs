namespace GameDeals.Application.Interfaces;
public interface IAuthenticationService
{
	Task LoginAsync(string email, string password);
}
