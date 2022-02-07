namespace SoftwareAPI.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SoftwareAPI.Services.Database.Interfaces;
    using SoftwareAPI.DTOs.Game;

    [ApiController]
	[Route("api/[controller]")]
	public class GameController : ControllerBase
	{
		public GameController(IGameService gameService)
		{
			this.GameService = gameService;
		}

		public IGameService GameService { get; }

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			GetAllGamesDTO games = await this.GameService.GetAllAsync<GetAllGamesDTO>();

			return this.Ok(games);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			GetGameDTO game = await this.GameService.GetByIdAsync<GetGameDTO>(id);

			if (game == null)
			{
				return this.NotFound();
			}

			return this.Ok(game);
		}


		[HttpPost]
		public async Task<IActionResult> Post(PostGameDTO model)
		{
			GetGameDTO createdGame = await this.GameService.AddAsync<GetGameDTO>(model);

			return this.CreatedAtRoute(this.RouteData, createdGame);
		}

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
	}
}
