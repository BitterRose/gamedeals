﻿using GameDeals.Application.Interfaces;
using GameDeals.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameDeals.Api.Controllers;

[ApiController]
[Route("api/")]
public class UsersController : ControllerBase
{
	private readonly IUsersService _usersService;

	public UsersController(IUsersService usersService)
	{
		_usersService = usersService;
	}

	[HttpPost]
	[AllowAnonymous]
	[Route("register")]
	public async Task<IActionResult> Register([FromBody] RegisterDto register)
	{
		await _usersService.RegisterAsync(register);
		return Created(nameof(Register), null);
	}

	[HttpPost]
	[AllowAnonymous]
	[Route("login")]
	public async Task<IActionResult> Login([FromBody] LoginDto login)
	{
		var accessToken = await _usersService.LoginAsync(login);
		return Ok(new { AccessToken = accessToken });
	}
}