namespace SoftwareAPI.Services.Database.Interfaces
{
    using SoftwareAPI.DTOs.Game;
    using System;
    using System.Threading.Tasks;

    public interface IGameService
    {
        Task<T> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(Guid id);

        Task<T> AddAsync<T>(PostGameDTO game);

        Task<bool> UpdateAsync(Guid id, PutGameDTO game);

        Task<bool> PartialUpdateAsync(Guid id, PatchGameDTO game);

        Task<bool> DeleteAsync(Guid id);
    }
}
