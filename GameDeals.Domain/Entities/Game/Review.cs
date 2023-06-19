namespace GameDeals.Domain.Entities.Game;
public class Review
{
	public Guid Id { get; private set; }
	public string Title { get; init; }
	public string Description { get; init; }
	public int Rating { get; init; }

	public Review(string title, string description, int rating)
	{
		Id = Guid.NewGuid();
		Title = title;
		Description = description;
		Rating = rating;
	}

	private Review() { }
}
