using System;
using System.Text.Json.Serialization;
using MusicTrackAPI.Model.Interface;

namespace MusicTrackAPI.Model
{
    public class ApiEntity : IApiEntity<int>
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
    }
}

