using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Data.Domain.Interface;
using MusicTrackAPI.Model.Interface;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/[controller]")]
	public class ApiController<TEntity, TApiEntity>: ControllerBase
		where TEntity: IEntity<int>
        where TApiEntity : IApiEntity<int>
    {
        private readonly IDataService<TEntity, TApiEntity> dataService;

        public ApiController(IDataService<TEntity, TApiEntity> dataService)
		{
            this.dataService = dataService;
        }

		[HttpGet]
		public async Task<IActionResult> BulkGet()
        {
			return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id, CancellationToken ct)
        {
            return Ok(await dataService.GetByIdAsync(id, ct));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TApiEntity apiModel, CancellationToken ct)
        {
            return Ok(await dataService.CreateAsync(apiModel, ct));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TApiEntity apiModel, CancellationToken ct)
        {
            return Ok(await dataService.UpdateAsync(apiModel, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken ct)
        {
            return Ok(await dataService.DeleteAsync(id, ct));
        }
    }
}

