﻿namespace GameDeals.Domain.Services;
public interface IJwtService
{
	string GenerateToken(Guid userId, string email, string role);
}
