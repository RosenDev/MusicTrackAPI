    using System;
    using MusicTrackAPI.Data.Domain.Interface;
using MusicTrackAPI.Model.Interface;

namespace MusicTrackAPI.Services.Interface
{
	    public interface IDataService<TEntity, TApiEntity>
        where TEntity: IEntity<int>
        where TApiEntity: IApiEntity<int>
	    {
             Task<int> CreateAsync(TApiEntity apiModel, CancellationToken ct);

             Task<int> UpdateAsync(TApiEntity apiModel, CancellationToken ct);

             Task<TApiEntity> GetByIdAsync(int id, CancellationToken ct);

             Task<bool> DeleteAsync(int id, CancellationToken ct);
        }
    }

