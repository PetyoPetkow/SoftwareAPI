using Microsoft.EntityFrameworkCore;
using SoftwareAPI.Database.Models.Software;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAPI.Database
{
    public class SoftwareAPIDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<GameGenreMapping> GamesGenresMapping { get; set; }

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
