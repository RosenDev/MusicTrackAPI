namespace MusicTrackAPI.Data.Domain.Interface
{
    public interface IEntity<T> : IAuditInfo, IDeletable
	{
		T Id { get; }
	}
}

