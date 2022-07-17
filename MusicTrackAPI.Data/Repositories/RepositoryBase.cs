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
            return await ApplyInclude(Set).FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public virtual async Task<List<TEntity>> QueryAsync(List<Expression<Func<TEntity, bool>>> query, Paging paging, CancellationToken ct)
        {
            Expression<Func<TEntity, bool>> fakeExpression = x => true;
            var queryExpression = Expression.And(fakeExpression, fakeExpression);

            query.ForEach(x => { queryExpression = Expression.And(queryExpression, x); });

            var lambdaExpression = Expression.Lambda<Func<TEntity, bool>>(queryExpression, new ParameterExpression[] { Expression.Parameter(typeof(TEntity)) });

            return await ApplyInclude(Set.AsQueryable()).AsNoTracking()
                .Where(x=> lambdaExpression.Compile()(x))
                .Skip(paging.Page - 1)
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

      protected virtual IQueryable<TEntity> ApplyInclude(IQueryable<TEntity> query)
      {
          return query;
      }
    }
}

