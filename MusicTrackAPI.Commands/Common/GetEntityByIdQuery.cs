using MediatR;
using MusicTrackAPI.Model.Interface;

namespace MusicTrackAPI.Commands.Common
{
    public class GetEntityByIdQuery<TApiEntity> : IRequest<TApiEntity>
        where TApiEntity : IApiEntity<int>
    {
        public int Id { get; set; }
    }
}
