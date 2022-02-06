namespace SoftwareAPI.Services.Database.Interfaces
{
    using SoftwareAPI.DTOs.Genre;
    using System;
	using System.Threading.Tasks;

	public interface IGenreService
	{
		Task<T> GetAllAsync<T>();

		Task<T> GetByIdAsync<T>(Guid id);

		Task<T> AddAsync<T>(PostGenreDTO model);

		Task<bool> UpdateAsync(Guid id, PutGenreDTO model);

		Task<bool> DeleteAsync(Guid id);
	}
}
