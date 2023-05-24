using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Common;
using MusicTrackAPI.Data.Domain.Interface;
using MusicTrackAPI.Model.Interface;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ApiController<TEntity, TApiEntity> : ControllerBase
        where TEntity : IEntity<int>
        where TApiEntity : IApiEntity<int>
    {
        private readonly IDataService<TEntity, TApiEntity> dataService;
        protected readonly ILogger<ApiController<TEntity, TApiEntity>> logger;

        public ApiController(
            IDataService<TEntity, TApiEntity> dataService,
            ILogger<ApiController<TEntity, TApiEntity>> logger
            )
        {
            this.dataService = dataService;
            this.logger = logger;
        }

        [HttpPost("search")]
        public virtual async Task<IActionResult> QueryAsync([FromBody] List<FieldFilter> filters, [FromQuery] Paging paging, CancellationToken ct)
        {
            try
            {
                var result = await dataService.QueryAsync(filters, paging, ct);

                return Ok(result);
            }
            catch(Exception ex)
            {
                logger.LogWarning(ex.Message);

                throw;
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById([FromRoute] int id, CancellationToken ct)
        {
            try
            {
                return Ok(await dataService.GetByIdAsync(id, ct));
            }
            catch(Exception ex)
            {
                logger.LogWarning(ex.Message);

                throw;
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int id, CancellationToken ct)
        {
            try
            {
                await dataService.DeleteAsync(id, ct);

                return Ok();
            }
            catch(Exception ex)
            {
                logger.LogWarning(ex.Message);

                throw;
            }
        }
    }
}

