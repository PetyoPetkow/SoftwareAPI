namespace SoftwareAPI.Database
{
	using Microsoft.EntityFrameworkCore;
	using SoftwareAPI.Database.Models.Software;
	using System.Reflection;

	public class SoftwareAPIDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<GameGenreMapping> GamesGenresMapping { get; set; }

		public DbSet<Type> Types { get; set; }

		public DbSet<Utility> Utilities { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseSqlServer("Server=.;Database=SoftwareAPI;Integrated Security = true;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
