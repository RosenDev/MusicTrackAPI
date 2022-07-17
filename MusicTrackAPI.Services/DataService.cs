
using System;
using System.Linq.Expressions;
using AutoMapper;
using MusicTrackAPI.Common;
using MusicTrackAPI.Data.Domain.Interface;
using MusicTrackAPI.Data.Repositories;
using MusicTrackAPI.Data.Repositories.Interfaces;
using MusicTrackAPI.Model.Interface;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Services
{
    public class DataService<TEntity, TApiEntity> : IDataService<TEntity, TApiEntity>
        where TEntity : IEntity<int>
        where TApiEntity : IApiEntity<int>
    {
        protected readonly IRepositoryBase<TEntity> repositoryBase;
        protected readonly IMapper mapper;

        public DataService(IRepositoryBase<TEntity> repositoryBase, IMapper mapper)
        {
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
        }

        public virtual async Task<int> CreateAsync(TApiEntity apiModel, CancellationToken ct)
        {
            return (await repositoryBase.AddAsync(mapper.Map<TEntity>(apiModel), ct)).Id;
        }

        public virtual async Task<int> UpdateAsync(TApiEntity apiModel, CancellationToken ct)
        {
            return (await repositoryBase.UpdateAsync(mapper.Map<TEntity>(apiModel), ct)).Id;
        }

        public virtual async Task<TApiEntity> GetByIdAsync(int id, CancellationToken ct)
        {
            return mapper.Map<TApiEntity>(await repositoryBase.FindAsync(id, ct));
        }

        public virtual async Task<PagedResponse<TApiEntity>> QueryAsync(DataFilters filters, Paging paging, CancellationToken ct)
        {
            return new PagedResponse<TApiEntity>
            {
                Result = (await repositoryBase.QueryAsync(paging, ct))
            };
        }

        public virtual async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            return await repositoryBase.DeleteAsync(id, ct);
        }

        private Expression ParseFilters()
        {

        }
    }
}

