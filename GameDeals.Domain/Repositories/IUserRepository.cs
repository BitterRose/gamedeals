﻿using GameDeals.Domain.Entities.Authenticate;

namespace GameDeals.Domain.Repositories;
public interface IUserRepository
{
	Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default);
	Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
	Task AddAsync(User user, CancellationToken cancellationToken = default);
	Task UpdateAsync(User user, CancellationToken cancellationToken = default);
}
