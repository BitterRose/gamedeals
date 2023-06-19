using GameDeals.Domain.Entity.Auth;
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
			new User("arkadiusz.kapalka", "Example)98", "arkadiusz.kapalka@microsoft.wsei.edu.pl", Role.Admin));
	}
}
