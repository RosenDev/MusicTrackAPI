using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicTrackAPI.Commands.Common;
using MusicTrackAPI.Common;
using MusicTrackAPI.Data.Domain.Interface;
using MusicTrackAPI.Model.Interface;

namespace MusicTrackAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ApiController<TEntity, TApiEntity> : ControllerBase
        where TEntity : IEntity<int>
        where TApiEntity : IApiEntity<int>
    {
        protected readonly IMediator mediator;
        protected readonly ILogger<ApiController<TEntity, TApiEntity>> logger;

        public ApiController(
            IMediator mediator,
            ILogger<ApiController<TEntity, TApiEntity>> logger
            )
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpPost("search")]
        public virtual async Task<IActionResult> QueryAsync([FromBody] List<FieldFilter> filters, [FromQuery] Paging paging, CancellationToken ct)
        {
            try
            {
                var result = await mediator.Send(new SearchEntityQuery<TApiEntity>
                {
                    Filters = filters,
                    Paging = paging
                });

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
                return Ok(await mediator.Send(new GetEntityByIdQuery<TApiEntity> { Id = id }));
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
                await mediator.Send(new DeleteEntityCommand<TApiEntity> { Id = id });

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

