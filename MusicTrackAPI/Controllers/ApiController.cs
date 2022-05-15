using System;
using Microsoft.AspNetCore.Mvc;

namespace MusicTrackAPI.Controllers
{
	[ApiController]
	public class ApiController: ControllerBase
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

