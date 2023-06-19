namespace GameDeals.Domain.Services;
public interface IPasswordManagerService
{
	string Generate(string password);
	bool IsValid(string password, string securedPassword);
}
