namespace SoftwareAPI.Services.Database
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SoftwareAPI.Database;
    using SoftwareAPI.Database.Models.Software;
    using SoftwareAPI.Services.Database.Interfaces;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class GameGenreMappingService : BaseService<GameGenreMapping>, IGameGenreMappingService
    {
		public GameGenreMappingService(SoftwareAPIDbContext dbContext, IMapper mapper)
			: base(dbContext, mapper)
		{

		}

		public async Task<T> GetByGameAndGenreIdAsync<T>(Guid gameId, Guid genreId)
		{
			var gameGenreRelation = await this.DbSet
				.Where(ggm => ggm.GameId == gameId
					&& ggm.GenreId == genreId)
				.Include(ggm => ggm.Game)
				.Include(ggm => ggm.Genre)
				.SingleOrDefaultAsync();

			if (gameGenreRelation == null)
			{
				throw new Exception();
			}

			var gameGenreRelationToReturn = this.Mapper.Map<T>(gameGenreRelation);
			return gameGenreRelationToReturn;
		}

		public async Task<T> AddAsync<T>(GameGenreMapping model)
		{
			GameGenreMapping genreToAdd = this.Mapper.Map<GameGenreMapping>(model);

			await this.DbSet.AddAsync(genreToAdd);
			await this.DbContext.SaveChangesAsync();

			T result = this.Mapper.Map<T>(genreToAdd);
			return result;
		}

		public async Task<bool> DeleteAsync(Guid gameId, Guid genreId)
		{
			var gameGenreRelationToDelete = await this.GetByGameAndGenreIdAsync<GameGenreMapping>(gameId, genreId);

			this.DbSet.Remove(gameGenreRelationToDelete);
			await this.DbContext.SaveChangesAsync();

			return true;
		}

        public Task<T> GetAllAsync<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
