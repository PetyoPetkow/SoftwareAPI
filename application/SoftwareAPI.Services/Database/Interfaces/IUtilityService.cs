using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAPI.Services.Database.Interfaces
{
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
