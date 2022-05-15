using System;
namespace MusicTrackAPI.Data.Domain.Interface
{
    public interface IAuditInfo
	{
		DateTime CreatedAt { get; }
		DateTime? UpdatedAt { get; }

	}
}

