using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicTrackAPI.Data.Domain;

namespace MusicTrackAPI.Data.Repositories
{
    public class RepositoryBase<TEntity>: IRepositoryBase<TEntity> where TEntity: MySqlEntity
	{
        protected MusicTrackAPIDbContext Context { get; }

        protected DbSet<TEntity> Set { get; }

        public RepositoryBase(MusicTrackAPIDbContext context, DbSet<TEntity> set)
		{
            Context = context;
            Set = set;
        }

        
        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await Set.FindAsync(id);

            if(entity != null)
            {
                Set.Remove(entity);
            }
            
           return (await Context.SaveChangesAsync(ct)) == 1;

        }

        public async Task<TEntity> FindAsync(int id, CancellationToken ct = default)
        {
            return await Set.FindAsync(new object[] { id }, ct);
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> query, CancellationToken ct = default)
        {
            return await Set.AsQueryable().AsNoTracking().Where(query).ToListAsync(ct);
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default)
        {
            Set.Add(entity);

            await Context.SaveChangesAsync(ct);

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct = default)
        {
            Set.Update(entity);

            await Context.SaveChangesAsync(ct);

            return entity;
        }
    }
}

