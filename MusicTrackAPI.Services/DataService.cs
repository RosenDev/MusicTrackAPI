
using System;
using AutoMapper;
using MusicTrackAPI.Data.Domain.Interface;
using MusicTrackAPI.Data.Repositories;
using MusicTrackAPI.Model.Interface;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Services
{
	public class DataService<TEntity, TApiEntity>: IDataService<TEntity, TApiEntity>
        where TEntity: IEntity<int>
        where TApiEntity: IApiEntity<int>
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

        public virtual async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            return await repositoryBase.DeleteAsync(id, ct);
        }
    }
}

