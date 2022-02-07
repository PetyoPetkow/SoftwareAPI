namespace SoftwareAPI.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using SoftwareAPI.DTOs.Utility;
	using SoftwareAPI.Services.Database.Interfaces;
	using System;
	using System.Threading.Tasks;

	[ApiController]
	[Route("api/[controller]")]
	public class UtilityController : ControllerBase
    {
        public UtilityController(IUtilityService utilityService)
        {
            this.UtilityService = utilityService;
        }

        public IUtilityService UtilityService { get; }

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			GetAllUtilitiesDTO utilities = await this.UtilityService.GetAllAsync<GetAllUtilitiesDTO>();

			return this.Ok(utilities);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			GetUtilityDTO utility = await this.UtilityService.GetByIdAsync<GetUtilityDTO>(id);

			if (utility == null)
			{
				return this.NotFound();
			}

			return this.Ok(utility);
		}

		[HttpPost]
		public async Task<IActionResult> Post(PostUtilityDTO model)
		{
			GetUtilityDTO createdUtility = await this.UtilityService.AddAsync<GetUtilityDTO>(model);

			return this.CreatedAtRoute(this.RouteData, createdUtility);
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> Put(Guid id, PutUtilityDTO model)
		{
			bool resultFromUpdate = await this.UtilityService.UpdateAsync(id, model);

			if (resultFromUpdate == false)
			{
				return this.BadRequest();
			}

			return this.NoContent();
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			bool resultFromDelete = await this.UtilityService.DeleteAsync(id);

			if (resultFromDelete == false)
			{
				return this.BadRequest();
			}

			return this.NoContent();
		}
	}
}
