using Microsoft.EntityFrameworkCore;
using SoftwareAPI.Database;
using SoftwareAPI.Database.Models.Software;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAPI.Services.Database
{

		public class GameService : BaseService<Game>
		{
			public GameService(SoftwareAPIDbContext dbContext)
				: base(dbContext)
			{

			}

			public async Task<Game> AddAsync(Game game)
			{
				await this.DbSet.AddAsync(game);

				await this.DbContext.SaveChangesAsync();

				return game;
			}
		}
	
}
