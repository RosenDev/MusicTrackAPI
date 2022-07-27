using System.Linq;
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
            Expression<Func<TEntity, bool>> fake = x => false;

            var binaryExpression = Expression.OrElse(fake , fake);

            var param = Expression.Parameter(typeof(TEntity), "entity");

            query.ForEach(x => binaryExpression = Expression.OrElse(binaryExpression, Expression.Invoke(x, param)));

            var lambda = Expression.Lambda<Func<TEntity, bool>>(binaryExpression, param);


            var result = await ApplyInclude(Set.Where(lambda)).AsNoTracking()
                .Skip(paging.Page - 1)
                .Take(paging.Size)
                .ToListAsync(ct);

            return result;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct)
        {
            entity.CreatedAt = DateTime.UtcNow;

            Set.Add(entity);

            await Context.SaveChangesAsync(ct);

            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct)
        {

            var existingEnitity = await Set.FirstOrDefaultAsync(x => x.Id == entity.Id, ct);

            entity.CreatedAt = existingEnitity.CreatedAt;

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

