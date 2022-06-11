namespace MusicTrackAPI.Data.Domain.Interface
{
    public interface IDeletable
	{
		bool IsDeleted { get; set; }
		DateTime? DeletedAt { get; set; }
	}
}

