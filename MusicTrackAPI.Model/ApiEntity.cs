using System;
using System.Text.Json.Serialization;
using MusicTrackAPI.Model.Interface;

namespace MusicTrackAPI.Model
{
    public class ApiEntity : IApiEntity<int>
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

