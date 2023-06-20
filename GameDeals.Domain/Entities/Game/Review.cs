namespace GameDeals.Domain.Entities.Game;
public class Review
{
	public Guid Id { get; private set; }
	public Guid GameId { get; init; }
	public Game Game { get; init; }
	public string Title { get; init; }
	public string? Description { get; init; }
	public int Rating { get; init; }


	public Review(Guid gameId, string title, string? description, int rating)
	{
		Id = Guid.NewGuid();
		GameId = gameId;
		Title = title;
		Description = description;
		Rating = rating;
	}

	private Review() { }
}
