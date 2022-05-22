using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MusicTrackAPI.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/[controller]")]
	public class ApiController<TModel>: ControllerBase
	{
		public ApiController()
		{
		}

		[HttpGet]
		public async Task<IActionResult> BulkGet()
        {
			return Ok();
        }
	}
}

