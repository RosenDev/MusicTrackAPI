using System.Linq.Expressions;
using MusicTrackAPI.Common;
using MusicTrackAPI.Data.Domain.Interface;

namespace MusicTrackAPI.Data.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity: IEntity<int>
	{

		Task<TEntity> FindAsync(int id, CancellationToken ct);

		Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> query, Paging paging, CancellationToken ct);

		Task<TEntity> AddAsync(TEntity entity, CancellationToken ct);

		Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct);

		Task<bool> DeleteAsync(int id, CancellationToken ct);

	}
}

