namespace SoftwareAPI.Services.Database
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SoftwareAPI.Database;
    using SoftwareAPI.Database.Models.Software;
    using SoftwareAPI.DTOs.Game;
    using SoftwareAPI.Services.Database.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    public class GameService : BaseService<Game>, IGameService
    {
        private readonly IGenreService genreService;
        private readonly IGameGenreMappingService gameGenreMappingService;

        public GameService(SoftwareAPIDbContext dbContext,
            IMapper mapper,
            IGenreService genreService, 
            IGameGenreMappingService gameGenreMappingService
            )
            : base(dbContext, mapper)
        {
            this.genreService = genreService;
            this.gameGenreMappingService = gameGenreMappingService;
        }

        public async Task<T> AddAsync<T>(PostGameDTO game)
        {
            Game gameToAdd = this.Mapper.Map<Game>(game);

            await this.DbSet.AddAsync(gameToAdd);
            await this.DbContext.SaveChangesAsync();

            T gameToReturn = this.Mapper.Map<T>(gameToAdd);

            return gameToReturn;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Game gameToDelete = await this.GetByIdAsync<Game>(id);

            if (gameToDelete == null)
            {
                throw new Exception();
            }

            gameToDelete.IsDeleted = true;
            gameToDelete.DeletedOn = DateTime.UtcNow;

            this.DbSet.Update(gameToDelete);
            int resultFromDb = await this.DbContext.SaveChangesAsync();

            bool result = resultFromDb != 0;
            return result;
        }

        public async Task<T> GetAllAsync<T>()
        {
            List<Game> games = await this.DbSet
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Publisher)
                .Include(g => g.Genres)
                .ThenInclude(g=>g.Genre)
                .Where(g => g.IsDeleted == false)
                .ToListAsync();

            T mappedGames = this.Mapper.Map<T>(games);
            return mappedGames;
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
        {
            Game game = await this.DbSet
                .Include(g => g.Genres)
                .SingleOrDefaultAsync(g => g.Id == id);

            T mappedGame = this.Mapper.Map<T>(game);

            return mappedGame;
        }

        public async Task<bool> PartialUpdateAsync(Guid id, PatchGameDTO game)
        {
            Game gameToUpdate = await this.GetByIdAsync<Game>(id);

            if (gameToUpdate == null)
            {
                return false;
            }

            System.Type modelType = game.GetType();
            PropertyInfo[] properties = modelType.GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                var propertyValue = propertyInfo.GetValue(game);
                if (propertyValue != null)
                {
                    System.Type propertyType = propertyInfo.PropertyType;
                    bool isPropertyTypeIEnumerable = propertyType.IsGenericType
                        && propertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>);

                    if (isPropertyTypeIEnumerable)
                    {
                        IEnumerable<Guid> genresId = propertyInfo.GetValue(game) as IEnumerable<Guid>;
                        await this.SaveGenresToGame(genresId, gameToUpdate);

                        continue;
                    }
                }
            }
            gameToUpdate.UpdatedOn = DateTime.UtcNow;

            this.DbContext.Update(gameToUpdate);
            await this.DbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, PutGameDTO game)
        {
            Game gameToUpdate = await this.GetByIdAsync<Game>(id);

            if (gameToUpdate == null)
            {
                return false;
            }
            Game updatedGame = this.Mapper.Map(game, gameToUpdate);
            updatedGame.UpdatedOn = DateTime.UtcNow;
            this.DbContext.Update(updatedGame);
            await this.DbContext.SaveChangesAsync();

            return true;
        }
        private async Task SaveGenresToGame(IEnumerable<Guid> genresId, Game game)
        {
            foreach (Guid genreId in genresId)
            {
                Genre genre = await genreService.GetByIdAsync<Genre>(genreId);
                if (genre == null)
                {
                    continue;
                }

                bool isGenreAlreadyAssigned = game.Genres
                    .Any(ggm => ggm.GameId == game.Id
                            && ggm.GenreId == genre.Id);
                if (isGenreAlreadyAssigned)
                {
                    continue;
                }

                GameGenreMapping gameGenreMapping = new GameGenreMapping
                {
                    GameId = game.Id,
                    GenreId = genre.Id
                };

                await this.gameGenreMappingService.AddAsync<GameGenreMapping>(gameGenreMapping);
            }
        }
    }

}
