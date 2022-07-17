using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicTrackAPI.Common;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories.Interfaces;

namespace MusicTrackAPI.Data.Repositories
{
    public class RepositoryBase<TEntity>: IRepositoryBase<TEntity> where TEntity: MySqlEntity
	{
        protected MusicTrackAPIDbContext Context { get; }

        protected DbSet<TEntity> Set { get; }

        public RepositoryBase(MusicTrackAPIDbContext context)
		{
            Context = context;
            Set = context.Set<TEntity>();
        }

        
        public virtual async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            var entity = await Set.FindAsync(id);

            if(entity != null)
            {
                Set.Remove(entity);
            }
            
           return (await Context.SaveChangesAsync(ct)) == 1;

        }

        public virtual async Task<TEntity> FindAsync(int id, CancellationToken ct)
        {
            return await Set.FindAsync(new object[] { id }, ct);
        }

        public virtual async Task<List<TEntity>> QueryAsync(List<Expression<Func<TEntity, bool>>> query, Paging paging, CancellationToken ct = default)
        {
            Expression<Func<TEntity, bool>> queryExpression = x => true;

            query.ForEach(x => { queryExpression = Expression.And(queryExpression, x); });

            return await Set.AsQueryable().AsNoTracking()
                .Where(queryExpression)
                .Skip(paging.Page)
                .Take(paging.Size)
                .ToListAsync(ct);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct)
        {
            Set.Add(entity);

            await Context.SaveChangesAsync(ct);

            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct)
        {
            Set.Update(entity);

            await Context.SaveChangesAsync(ct);

            return entity;
        }
    }
}

