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

		/// <summary>
		/// Get utility by Id
		/// </summary>
		/// <param name="id">The utility id</param>
		/// <returns>Returns the utility with the given id</returns>
		/// <response code="200">Returns the utility with the given id</response>
		/// <response code="404">If the utility is null</response>
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

		/// <summary>
		/// Get all utilities
		/// </summary>
		/// <returns>Returns all utilities that are not deleted</returns>
		/// <response code="200">Returns all utilities sorted by Name and Publisher</response>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			GetAllUtilitiesDTO utilities = await this.UtilityService.GetAllAsync<GetAllUtilitiesDTO>();

			return this.Ok(utilities);
		}

		/// <summary>
		/// Create a utility
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     POST /api/Utility
		///     {
		///        "name": "UtilityName",
		///        "publisher": "PublisherName"
		///        "description": "Description"
		///        "price": "Price"
		///     }
		///
		/// </remarks>
		/// <param name="model">Body model with data</param>
		/// <returns>The utility that is created</returns>
		/// <response code="200">If the utility is created successfully</response>
		/// <response code="400">If the request is not correct</response>
		[HttpPost]
		public async Task<IActionResult> Post(PostUtilityDTO model)
		{
			GetUtilityDTO createdUtility = await this.UtilityService.AddAsync<GetUtilityDTO>(model);

			return this.CreatedAtRoute(this.RouteData, createdUtility);
		}

		/// <summary>
		/// Update utility
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     PUT /api/Utility
		///     {
		///			"name": "UtilityName",
		///			"publisher": "PublisherName"
		///			"description": "Description"
		///			"price": "Price"
		///     }
		///
		/// </remarks>
		/// <param name="id">The utility id</param>
		/// <param name="model">Body model with data to update</param>
		/// <returns>The result from the update action</returns>
		/// <response code="200">If the utility is updated successfully</response>
		/// <response code="400">If the request is not correct</response>
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

		/// <summary>
		/// Partial update for a utility
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     PATCH /api/Utility
		///     {
		///        "name": "UtilityName",
		///        "publisher": "PublisherName"
		///        "description": "Description"
		///        "price": "Price"
		///     }
		///
		/// </remarks>
		/// <param name="id">The utility id</param>
		/// <param name="model">Body model with data to partial update</param>
		/// <returns>The result from the update action</returns>
		/// <response code="200">If the utility is updated successfully</response>
		/// <response code="400">If the request is not correct</response>
		[HttpPatch]
		[HttpPatch]
		[Route("{id}")]
		public async Task<IActionResult> Patch(Guid id, PatchUtilityDTO model)
		{
			bool resultFromPartialUpdate = await this.UtilityService.PartialUpdateAsync(id, model);
			if (resultFromPartialUpdate == false)
			{
				return this.BadRequest();
			}
			return this.Ok();
		}

		/// <summary>
		/// Delete utility by Id
		/// </summary>
		/// <param name="id">The utility id</param>
		/// <returns>The result from the delete action</returns>
		/// <response code="200">If the utility is deleted successfully</response>
		/// <response code="400">If the utility is null</response>
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
