using MediatR;
using MusicTrackAPI.Model.Interface;

namespace MusicTrackAPI.Commands.Common
{
    public class DeleteEntityCommand<TApiEntity> : IRequest
        where TApiEntity : IApiEntity<int>
    {
        public int Id { get; set; }
    }
}
