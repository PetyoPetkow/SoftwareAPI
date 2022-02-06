namespace SoftwareAPI.Services.Database.Interfaces
{
    using SoftwareAPI.Database.Models.Software;
    using System;
    using System.Threading.Tasks;

    public interface IGameGenreMappingService
    {
        Task<T> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(Guid id);

        Task<T> GetByGameAndGenreIdAsync<T>(Guid gameId, Guid genreId);

        Task<T> AddAsync<T>(GameGenreMapping model);

        Task<bool> DeleteAsync(Guid gameId, Guid genreId);
    }
}
