namespace SoftwareAPI.Services.Database.Interfaces
{
    using SoftwareAPI.DTOs.Type;
    using System;
    using System.Threading.Tasks;

    public interface ITypeService
    {
        Task<T> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(Guid id);

        Task<T> AddAsync<T>(PostTypeDTO model);

        Task<bool> UpdateAsync(Guid id, PutTypeDTO model);

        Task<bool> DeleteAsync(Guid id);
    }
}
