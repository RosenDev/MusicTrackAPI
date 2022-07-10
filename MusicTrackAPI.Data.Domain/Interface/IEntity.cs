namespace MusicTrackAPI.Data.Domain.Interface
{
    public interface IEntity<TKey> : IAuditInfo, IDeletable
		where TKey: struct
	{
		TKey Id { get; }
	}
}

