
using System.Linq.Expressions;
using AutoMapper;
using MusicTrackAPI.Common;
using MusicTrackAPI.Data.Domain.Interface;
using MusicTrackAPI.Data.Repositories.Interfaces;
using MusicTrackAPI.Model.Interface;
using MusicTrackAPI.Services.Interface;
using Microsoft.Extensions.Logging;
using MusicTrackAPI.Data.Domain;

namespace MusicTrackAPI.Services
{
    public class DataService<TEntity, TApiEntity> : IDataService<TEntity, TApiEntity>
        where TEntity : IEntity<int>
        where TApiEntity : IApiEntity<int>
    {
        protected readonly IRepositoryBase<TEntity> repositoryBase;
        protected readonly IMapper mapper;
        private readonly ILogger<DataService<TEntity, TApiEntity>> logger;

        public DataService(
            IRepositoryBase<TEntity> repositoryBase,
            IMapper mapper,
            ILogger<DataService<TEntity, TApiEntity>> logger
            )
        {
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
            this.logger = logger;
        }

        public virtual async Task<TApiEntity> GetByIdAsync(int id, CancellationToken ct)
        {
            return mapper.Map<TApiEntity>(await repositoryBase.FindAsync(id, ct));
        }

        public virtual async Task<PagedResponse<TApiEntity>> QueryAsync(List<FieldFilter> filters, Paging paging, CancellationToken ct)
        {

            var result = mapper.Map<List<TApiEntity>>(await repositoryBase.QueryAsync(ParseFilters(filters), paging, ct));

            return new PagedResponse<TApiEntity>
            {
                Result = result,
                Page = paging.Page,
                Size = paging.Size,
                TotalRecords = result.Count
            };
        }

        public virtual async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            return await repositoryBase.DeleteAsync(id, ct);
        }

        private List<Expression<Func<TEntity, bool>>> ParseFilters(List<FieldFilter> filters)
        {
            var parsedFilters = new List<Expression<Func<TEntity, bool>>>();

            try
            {
               foreach(var filter in filters)
                {
                    switch (filter.Type)
                    {
                        case FieldValueType.Number:

                            Expression<Func<TEntity, bool>> intExpr = x => (int)x.GetType().GetProperties().First(x=>x.Name.ToLower() == filter.Field).GetValue(x) == int.Parse(filter.Value);

                            parsedFilters.Add(intExpr);

                            break;

                        case FieldValueType.Text:

                            Expression<Func<TEntity, bool>> stringExpr = x => (string)x.GetType().GetProperties().First(x => x.Name.ToLower() == filter.Field).GetValue(x) == filter.Value;

                            parsedFilters.Add(stringExpr);

                            break;

                        case FieldValueType.TrackType:

                            Expression<Func<TEntity, bool>> trackTypeExpr = x => (TrackType)x.GetType().GetProperties().First(x => x.Name.ToLower() == filter.Field).GetValue(x) == Enum.Parse<TrackType>(filter.Value);

                            parsedFilters.Add(trackTypeExpr);

                            break;
                        default:
                            throw new InvalidOperationException("Invalid filter type!");
                           
                    }

                }

                return parsedFilters;

            }
              catch(Exception ex)
            {
                logger.LogWarning(ex.Message);

                throw;
            }
        }
    }
}

