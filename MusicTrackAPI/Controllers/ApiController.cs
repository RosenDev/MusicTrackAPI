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
            ILogger<ApiController<TEntity, TApiEntity>> logger)
        {
            this.dataService = dataService;
            this.logger = logger;
        }

        [HttpGet]
        public virtual async Task<IActionResult> QueryAsync([FromQuery] DataFilters filters, [FromQuery] Paging paging)
        {
            try
            { 
               return Ok();
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                logger.LogWarning(ex.Message);

                throw;
            }
        }

        [HttpPost]        
        public virtual async Task<IActionResult> Create([FromBody] TApiEntity apiModel, CancellationToken ct)
        {
            try
            { 
               return Ok(await dataService.CreateAsync(apiModel, ct));
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex.Message);

                throw;
            }
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update([FromBody] TApiEntity apiModel, CancellationToken ct)
        {
            try
            {

                return Ok(await dataService.UpdateAsync(apiModel, ct));
            }
            catch (Exception ex)
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

