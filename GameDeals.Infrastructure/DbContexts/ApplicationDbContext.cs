using GameDeals.Domain.Entities.Authenticate;
using GameDeals.Domain.Entities.Game;
using Microsoft.EntityFrameworkCore;

namespace GameDeals.Infrastructure.DbContexts;
public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	public DbSet<User> Users { get; set; }
	public DbSet<Genre> Genres { get; set; }
	public DbSet<Game> Games { get; set; }
	public DbSet<Review> Reviews { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
	}
}
