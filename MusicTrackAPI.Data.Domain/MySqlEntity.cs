using MusicTrackAPI.Data.Domain.Interface;

namespace MusicTrackAPI.Data.Domain;

public class MySqlEntity : IEntity<int>
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime DeletedAt { get; set; }
}

