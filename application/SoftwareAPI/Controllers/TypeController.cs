using Microsoft.AspNetCore.Mvc;
using SoftwareAPI.DTOs.Type;
using SoftwareAPI.Services.Database.Interfaces;
using System;
using System.Threading.Tasks;
namespace SoftwareAPI.Controllers
{
    public class TypeController : ControllerBase
    {
		public TypeController(ITypeService typeService)
		{
			this.TypeService = typeService;
		}
		public ITypeService TypeService { get; }

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			GetAllTypesDTO types = await this.TypeService.GetAllAsync<GetAllTypesDTO>();

			return this.Ok(types);
		}

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

		[HttpPost]
		public async Task<IActionResult> Post(PostTypeDTO model)
		{
			GetTypeDTO createdType = await this.TypeService.AddAsync<GetTypeDTO>(model);

			return this.CreatedAtRoute(this.RouteData, createdType);
		}

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
