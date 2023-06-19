using GameDeals.Domain.Entities.Authenticate;
using Microsoft.EntityFrameworkCore;

namespace GameDeals.Infrastructure.DbContexts;
public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		modelBuilder.Entity<User>().HasData(
			new User("arkadiusz.kapalka@microsoft.wsei.edu.pl", "Example)98", Role.Admin));
	}
}
