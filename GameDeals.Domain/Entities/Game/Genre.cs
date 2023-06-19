﻿namespace GameDeals.Domain.Entities.Game;
public class Genre
{
	public Guid Id { get; private set; }
	public string Name { get; init; }

	public Genre(string name)
	{
		Id = Guid.NewGuid();
		Name = name;
	}

	private Genre() { }
}