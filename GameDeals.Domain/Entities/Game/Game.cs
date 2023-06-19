namespace GameDeals.Domain.Entities.Game;
public class Game
{
	public Guid Id { get; private set; }
	public string Name { get; init; }
	public Genre Genre { get; init; }
	public string Description { get; init; }
	public string? ImageUrl { get; init; }
	public decimal Price { get; init; }
	public virtual List<Review> Reviews { get; init; }

	public Game(string name, Genre genre, string description, string? imageUrl, decimal price)
	{
		Id = Guid.NewGuid();
		Name = name;
		Genre = genre;
		Description = description;
		ImageUrl = imageUrl;
		Price = price;
	}

	private Game() { }
}
