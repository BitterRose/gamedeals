namespace GameDeals.Domain.Services;
public interface IPasswordManager
{
	string Generate(string password);
	bool IsValid(string password, string securedPassword);
}
