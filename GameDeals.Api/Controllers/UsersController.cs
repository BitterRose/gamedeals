using GameDeals.Application.Interfaces;
using GameDeals.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameDeals.Api.Controllers;

[ApiController]
[Route("api/")]
public class UsersController : ControllerBase
{
	private readonly IUsersService _usersService;
	private readonly IAuthenticationService _authenticationService;

	public UsersController(IUsersService usersService, IAuthenticationService authenticationService)
	{
		_authenticationService = authenticationService;
		_usersService = usersService;
	}

	[HttpPost]
	[AllowAnonymous]
	[Route("register")]
	public async Task<IActionResult> Register([FromBody] RegisterDto register)
	{
		await _usersService.RegisterAsync(register);
		return Created(nameof(Register),null);
	}

	[HttpPost]
	[AllowAnonymous]
	[Route("login")]
	public async Task<IActionResult> Login([FromBody] LoginDto login)
	{
		await _authenticationService.LoginAsync(login.Email, login.Password);
		
		var accessToken = await _usersService.GetToken(login);
		return Ok(new {AccessToken = accessToken});
	}
}