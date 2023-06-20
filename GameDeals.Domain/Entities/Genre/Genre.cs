namespace GameDeals.Domain.Entities.Genre;
public class Genre
{
	public Guid Id { get; private set; }
	public string Name { get; init; }

	public Genre(string name)
	{
		Id = Guid.NewGuid();
		Name = name;
	}

	public Genre(Guid id, string name)
	{
		Id = id;
		Name = name;
	}

	private Genre() { }
}
