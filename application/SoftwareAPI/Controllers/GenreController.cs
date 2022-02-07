namespace SoftwareAPI.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using SoftwareAPI.DTOs.Genre;
	using SoftwareAPI.Services.Database.Interfaces;
	using System;
	using System.Threading.Tasks;

	public class GenreController : BaseAPIController
    {
		public GenreController(IGenreService genreService)
		{
			this.GenreService = genreService;
		}
		public IGenreService GenreService { get; }

		/// <summary>
		/// Get Genre by Id
		/// </summary>
		/// <param name="id">The genre id</param>
		/// <returns>Returns the genre with the given id</returns>
		/// <response code="200">Returns the genre with the given id</response>
		/// <response code="404">If the genre is null</response>
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			GetGenreDTO genre = await this.GenreService.GetByIdAsync<GetGenreDTO>(id);

			if (genre == null)
			{
				return this.NotFound();
			}
			return this.Ok(genre);
		}

		/// <summary>
		/// Get all genres
		/// </summary>
		/// <returns>Returns all genres that are not deleted</returns>
		/// <response code="200">Returns all genres sorted by Name</response>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			GetAllGenresDTO genres = await this.GenreService.GetAllAsync<GetAllGenresDTO>();

			return this.Ok(genres);
		}

		/// <summary>
		/// Create a genre
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     POST /api/Genre
		///     {
		///        "name": "GenreName"
		///     }
		///
		/// </remarks>
		/// <param name="model">Body model with data</param>
		/// <returns>The genre that is created</returns>
		/// <response code="200">If the genre is created successfully</response>
		/// <response code="400">If the request is not correct</response>
		[HttpPost]
		public async Task<IActionResult> Post(PostGenreDTO model)
		{
			GetGenreDTO createdGenre = await this.GenreService.AddAsync<GetGenreDTO>(model);

			return this.CreatedAtRoute(this.RouteData, createdGenre);
		}

		/// <summary>
		/// Update genre
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     PUT /api/Genre
		///     {
		///			"name": "GenreName",
		///     }
		///
		/// </remarks>
		/// <param name="id">The genre id</param>
		/// <param name="model">Body model with data to update</param>
		/// <returns>The result from the update action</returns>
		/// <response code="200">If the genre is updated successfully</response>
		/// <response code="400">If the request is not correct</response>
		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> Put(Guid id, PutGenreDTO model)
		{
			bool resultFromUpdate = await this.GenreService.UpdateAsync(id, model);

			if (resultFromUpdate == false)
			{
				return this.BadRequest();
			}
			return this.NoContent();
		}

		/// <summary>
		/// Delete genre by Id
		/// </summary>
		/// <param name="id">The genre id</param>
		/// <returns>The result from the delete action</returns>
		/// <response code="200">If the genre is deleted successfully</response>
		/// <response code="400">If the genre is null</response>
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			bool resultFromDelete = await this.GenreService.DeleteAsync(id);
			if (resultFromDelete == false)
			{
				return this.BadRequest();
			}
			return this.NoContent();
		}
	}
}

