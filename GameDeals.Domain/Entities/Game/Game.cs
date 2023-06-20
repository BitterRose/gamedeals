namespace GameDeals.Domain.Entities.Game;
public class Game
{
	public Guid Id { get; private set; }
	public string Name { get; init; }
	public Genre.Genre Genre { get; init; }
	public string Description { get; init; }
	public byte[]? ImageUrl { get; init; }
	public decimal Price { get; init; }
	public IReadOnlyList<Review.Review> Reviews { get; init; } = new List<Review.Review>();

	public Game(string name, Genre.Genre genre, string description, byte[]? imageUrl, decimal price)
	{
		Id = Guid.NewGuid();
		Name = name;
		Genre = genre;
		Description = description;
		ImageUrl = imageUrl;
		Price = price;
	}

	public Game(Guid id, string name, Genre.Genre genre, string description, byte[]? imageUrl, decimal price)
	{
		Id = id;
		Name = name;
		Genre = genre;
		Description = description;
		ImageUrl = imageUrl;
		Price = price;
	}

	private Game() { }
}
