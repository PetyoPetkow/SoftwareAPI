namespace SoftwareAPI.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	using SoftwareAPI.Database.Models.Software;
	using SoftwareAPI.Services.Database;
	

	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	[Route("api/[controller]")]
	public class GameController : ControllerBase
	{
		public GameController(GameService gameService)
		{
			this.GameService = gameService;
		}

		public GameService GameService { get; }
	}
}
