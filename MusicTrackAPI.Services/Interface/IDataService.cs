    using System;
using MusicTrackAPI.Common;
using MusicTrackAPI.Data.Domain.Interface;
using MusicTrackAPI.Model.Interface;

namespace MusicTrackAPI.Services.Interface
{
	    public interface IDataService<TEntity, TApiEntity>
        where TEntity: IEntity<int>
        where TApiEntity: IApiEntity<int>
	    {
             Task<TApiEntity> GetByIdAsync(int id, CancellationToken ct);

             Task<PagedResponse<TApiEntity>> QueryAsync(List<FieldFilter> filters, Paging paging, CancellationToken ct);

             Task<bool> DeleteAsync(int id, CancellationToken ct);
        }
    }

