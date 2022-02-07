namespace SoftwareAPI.Controllers
{
    using System;
    using System.Threading.Tasks;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
    using SoftwareAPI.Services.Database.Interfaces;
    using SoftwareAPI.DTOs.Game;
    using SoftwareAPI.Database.Models.Software;

    [Produces("application/json")]
	[ApiController]
	[Route("api/[controller]")]
	public class GameController : ControllerBase
	{
        public GameController(IGameService gameService, IGameGenreMappingService gameGenreMappingService)
		{
			this.GameService = gameService;
			this.GameGenreMappingService = gameGenreMappingService;
		}

		public IGameService GameService { get; }
        public IGameGenreMappingService GameGenreMappingService { get;}

        /// <summary>
        /// Get Game by Id
        /// </summary>
        /// <param name="id">The game id</param>
        /// <returns>Returns the game with the given id</returns>
        /// <response code="200">Returns the game with the given id</response>
        /// <response code="404">If the game is null</response>
        [HttpGet]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Get(Guid id)
		{
			GetGameDTO game = await this.GameService.GetByIdAsync<GetGameDTO>(id);

			if (game == null)
			{
				return this.NotFound();
			}

			return this.Ok(game);
		}

		/// <summary>
		/// Get all games
		/// </summary>
		/// <returns>Returns all games that are not deleted</returns>
		/// <response code="200">Returns all games sorted by Name and Publisher</response>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			GetAllGamesDTO games = await this.GameService.GetAllAsync<GetAllGamesDTO>();

			return this.Ok(games);
		}

		/// <summary>
		/// Create a game
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     POST /api/Game
		///     {
		///        "name": "GameName",
		///        "publisher": "PublisherName"
		///        "description": "Description"
		///        "price": "Price"
		///     }
		///
		/// </remarks>
		/// <param name="model">Body model with data</param>
		/// <returns>The game that is created</returns>
		/// <response code="200">If the game is created successfully</response>
		/// <response code="400">If the request is not correct</response>
		[HttpPost]
		public async Task<IActionResult> Post(PostGameDTO model)
		{
			if (TryValidateModel(model)) 
            {
				GetGameDTO createdGame = await this.GameService.AddAsync<GetGameDTO>(model);

				return this.CreatedAtRoute(this.RouteData, createdGame);
			}
			return this.BadRequest();
			
		}

        /// <summary>
        /// Update game
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Game
        ///     {
        ///			"name": "GameName",
        ///			"publisher": "PublisherName"
        ///			"description": "Description"
        ///			"price": "Price"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">The game id</param>
        /// <param name="model">Body model with data to update</param>
        /// <returns>The result from the update action</returns>
        /// <response code="200">If the game is updated successfully</response>
        /// <response code="400">If the request is not correct</response>
        [HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> Put(Guid id, PutGameDTO model)
		{
			bool resultFromUpdate = await this.GameService.UpdateAsync(id, model);

			if (resultFromUpdate == false)
			{
				return this.BadRequest();
			}

			return this.NoContent();
		}


		/// <summary>
		/// Partial update for a game
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     PATCH /api/Game
		///     {
		///        "name": "GameName",
		///        "publisher": "PublisherName"
		///        "description": "Description"
		///        "price": "Price"
		///     }
		///
		/// </remarks>
		/// <param name="id">The game id</param>
		/// <param name="model">Body model with data to partial update</param>
		/// <returns>The result from the update action</returns>
		/// <response code="200">If the game is updated successfully</response>
		/// <response code="400">If the request is not correct</response>
		[HttpPatch]
		[Route("{id}")]
		public async Task<IActionResult> Patch(Guid id, PatchGameDTO model)
		{
			bool resultFromPartialUpdate = await this.GameService.PartialUpdateAsync(id, model);
			if (resultFromPartialUpdate == false)
			{
				return this.BadRequest();
			}
			return this.Ok();
		}

		/// <summary>
		/// Delete game by Id
		/// </summary>
		/// <param name="id">The game id</param>
		/// <returns>The result from the delete action</returns>
		/// <response code="200">If the game is deleted successfully</response>
		/// <response code="400">If the game is null</response>
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			bool resultFromDelete = await this.GameService.DeleteAsync(id);

			if (resultFromDelete == false)
			{
				return this.BadRequest();
			}

			return this.NoContent();
		}

		/// <summary>
		/// Delete genre from a game
		/// </summary>
		/// <param name="gameId">The game id</param>
		/// <param name="genreId">The genre id</param>
		/// <returns>The result from the delete action</returns>
		/// <response code="200">If the relation is deleted successfully</response>
		/// <response code="400">If there is no relation</response>
		[HttpDelete]
		public async Task<IActionResult> Delete(Guid gameId, Guid genreId)
		{
			bool resultFromDelete = await this.GameGenreMappingService.DeleteAsync(gameId, genreId);

			if (resultFromDelete == false)
			{
				return this.BadRequest();
			}

			return this.Ok(resultFromDelete);
		}
	}
}
