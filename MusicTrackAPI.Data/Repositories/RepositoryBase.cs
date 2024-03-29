﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicTrackAPI.Common;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories.Interfaces;

namespace MusicTrackAPI.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : MySqlEntity
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

            if (entity != null)
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
            if(query.Count == 0)
            {
                return await ApplyInclude(Set).AsNoTracking()
                .Skip(paging.Page - 1)
                .Take(paging.Size)
                .ToListAsync(ct);
            }

            var search = BuildSearchQuery(query);

            var result = await ApplyInclude(Set.Where(search)).AsNoTracking()
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
            Set.Update(entity);

            await Context.SaveChangesAsync(ct);

            return entity;
        }

        protected virtual IQueryable<TEntity> ApplyInclude(IQueryable<TEntity> query)
        {
            return query;
        }

        public async Task<int> CountAsync(List<Expression<Func<TEntity, bool>>> query)
        {
            if(query.Count == 0)
            {
                return await Set.CountAsync();
            }

            var search = BuildSearchQuery(query);

            return await Set.CountAsync(search);
        }

        private Expression<Func<TEntity, bool>> BuildSearchQuery(List<Expression<Func<TEntity, bool>>> query)
        {

            var search = query[0];
            var paramName = search.Parameters.First().Name;
            var param = Expression.Parameter(typeof(TEntity), paramName);

            for(int i = 1; i < query.Count; i++)
            {
                search = Expression.Lambda<Func<TEntity, bool>>(Expression.AndAlso(search.Body, query[i].Body), param);
            }

            return search;
        }
    }
}

