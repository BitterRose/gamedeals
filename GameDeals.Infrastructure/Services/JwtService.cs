using GameDeals.Domain.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameDeals.Infrastructure.Services;
public class JwtService : IJwtService
{
	public string GenerateToken(Guid userId, string email, string role)
	{
		SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7LyqiTXsZInsa5ZW7LyqiTXsZInsa5ZW7LyqiTXsZInsa5ZW7LyqiTXsZInsa5ZW"));
		SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
		DateTime operationDate = DateTime.Now;

		SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
		{
			Audience = "https://localhost:7127",
			Issuer = "https://localhost:7127",
			Subject = new ClaimsIdentity(new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, $"{userId}"),
				new Claim(JwtRegisteredClaimNames.UniqueName, $"{userId}"),
				new Claim(JwtRegisteredClaimNames.Jti, $"{Guid.NewGuid()}"),
				new Claim(JwtRegisteredClaimNames.Email, email),
				new Claim(ClaimTypes.Role, role),
			}),
			NotBefore = operationDate,
			IssuedAt = operationDate,
			Expires = operationDate.AddDays(1),
			SigningCredentials = signingCredentials
		};

		JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
		SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(securityToken);
	}
}