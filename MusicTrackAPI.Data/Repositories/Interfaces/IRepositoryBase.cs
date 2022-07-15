using System.Linq.Expressions;
using MusicTrackAPI.Data.Domain.Interface;

namespace MusicTrackAPI.Data.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity: IEntity<int>
	{

		Task<TEntity> FindAsync(int id, CancellationToken ct = default);

		Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> query, CancellationToken ct = default);

		Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default);

		Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct = default);

		Task<bool> DeleteAsync(int id, CancellationToken ct = default);

	}
}

