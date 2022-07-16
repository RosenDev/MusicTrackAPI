using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTrackAPI.Model
{
    public class TrackModel: ApiEntity
    {
        public string Name { get; set; }
        public string WrittenBy { get; set; }
        public string PerformedBy { get; set; }
        public string ArrangedBy { get; set; }
        public TimeSpan Duration { get; set; }
        public TrackType Type { get; set; }
    }
}
