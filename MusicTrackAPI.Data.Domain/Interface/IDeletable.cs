namespace MusicTrackAPI.Data.Domain.Interface
{
    public interface IDeletable
	{
		bool IsDeleted { get; }
		DateTime DeletedAt { get; }
	}
}

