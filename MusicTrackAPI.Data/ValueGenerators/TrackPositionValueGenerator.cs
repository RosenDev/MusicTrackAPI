using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using MusicTrackAPI.Data.Domain;

namespace MusicTrackAPI.Data.ValueGenerators
{
    public class TrackPositionValueGenerator: ValueGenerator<int>
    {
        private int CurrentValue { get; set; } = 1;

        public override bool GeneratesTemporaryValues => false;

        public override int Next(EntityEntry entry)
        {
            return CurrentValue++;
        }
    }
}

