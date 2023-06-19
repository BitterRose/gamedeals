using GameDeals.Domain.Entities.Authenticate;
using GameDeals.Domain.Repositories;
using GameDeals.Domain.Services;
using GameDeals.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace GameDeals.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
	private readonly ApplicationDbContext _applicationDbContext;
	private readonly IPasswordManager _passwordManager;

	public UserRepository(ApplicationDbContext applicationDbContext, IPasswordManager passwordManager)
	{
		_applicationDbContext = applicationDbContext;
		_passwordManager = passwordManager;
	}

	public async Task AddAsync(string email, string password, Role role, CancellationToken cancellationToken = default)
	{
		User newUser = new User(email, _passwordManager.Generate(password), role);
		await _applicationDbContext.Users.AddAsync(newUser, cancellationToken);
		await _applicationDbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default)
	{
		User? user = await _applicationDbContext.Users.FindAsync(id);
		return user;
	}

	public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
	{
		User? user = await _applicationDbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
		return user;
	}

	public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
	{
		_applicationDbContext.Users.Update(user);
		await _applicationDbContext.SaveChangesAsync(cancellationToken);
	}
}
