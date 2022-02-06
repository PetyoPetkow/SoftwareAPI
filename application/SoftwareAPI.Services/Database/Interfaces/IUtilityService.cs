namespace SoftwareAPI.Services.Database.Interfaces
{
    using SoftwareAPI.DTOs.Utility;
    using System;
    using System.Threading.Tasks;

    public interface IUtilityService
    {
        Task<T> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(Guid id);

        Task<T> AddAsync<T>(PostUtilityDTO utility);

        Task<bool> UpdateAsync(Guid id, PutUtilityDTO utility);

        Task<bool> PartialUpdateAsync(Guid id, PatchUtilityDTO utility);

        Task<bool> DeleteAsync(Guid id);
    }
}
