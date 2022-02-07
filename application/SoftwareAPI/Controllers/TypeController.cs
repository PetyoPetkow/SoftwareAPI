using Microsoft.AspNetCore.Mvc;
using SoftwareAPI.DTOs.Type;
using SoftwareAPI.Services.Database.Interfaces;
using System;
using System.Threading.Tasks;
namespace SoftwareAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TypeController : ControllerBase
    {
		public TypeController(ITypeService typeService)
		{
			this.TypeService = typeService;
		}
		public ITypeService TypeService { get; }

		/// <summary>
		/// Get Type by Id
		/// </summary>
		/// <param name="id">The type id</param>
		/// <returns>Returns the type with the given id</returns>
		/// <response code="200">Returns the type with the given id</response>
		/// <response code="404">If the type is null</response>
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			GetTypeDTO type = await this.TypeService.GetByIdAsync<GetTypeDTO>(id);

			if (type == null)
			{
				return this.NotFound();
			}
			return this.Ok(type);
		}

		/// <summary>
		/// Get all types
		/// </summary>
		/// <returns>Returns all types that are not deleted</returns>
		/// <response code="200">Returns all types sorted by Name</response>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			GetAllTypesDTO types = await this.TypeService.GetAllAsync<GetAllTypesDTO>();

			return this.Ok(types);
		}

		/// <summary>
		/// Create a type
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     POST /api/Type
		///     {
		///        "name": "TypeName"
		///     }
		///
		/// </remarks>
		/// <param name="model">Body model with data</param>
		/// <returns>The type that is created</returns>
		/// <response code="200">If the type is created successfully</response>
		/// <response code="400">If the request is not correct</response>
		[HttpPost]
		public async Task<IActionResult> Post(PostTypeDTO model)
		{
			GetTypeDTO createdType = await this.TypeService.AddAsync<GetTypeDTO>(model);

			return this.CreatedAtRoute(this.RouteData, createdType);
		}

		/// <summary>
		/// Update type
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     PUT /api/Type
		///     {
		///			"name": "TypeName",
		///     }
		///
		/// </remarks>
		/// <param name="id">The type id</param>
		/// <param name="model">Body model with data to update</param>
		/// <returns>The result from the update action</returns>
		/// <response code="200">If the type is updated successfully</response>
		/// <response code="400">If the request is not correct</response>
		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> Put(Guid id, PutTypeDTO model)
		{
			bool resultFromUpdate = await this.TypeService.UpdateAsync(id, model);

			if (resultFromUpdate == false)
			{
				return this.BadRequest();
			}
			return this.NoContent();
		}

		/// <summary>
		/// Delete type by Id
		/// </summary>
		/// <param name="id">The type id</param>
		/// <returns>The result from the delete action</returns>
		/// <response code="200">If the type is deleted successfully</response>
		/// <response code="400">If the type is null</response>
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			bool resultFromDelete = await this.TypeService.DeleteAsync(id);
			if (resultFromDelete == false)
			{
				return this.BadRequest();
			}
			return this.NoContent();
		}
	}
}
