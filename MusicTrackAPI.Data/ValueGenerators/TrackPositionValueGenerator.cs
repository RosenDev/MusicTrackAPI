using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using MusicTrackAPI.Data.Domain;

namespace MusicTrackAPI.Data.ValueGenerators
{
    public static class TrackPositionValueGenerator
    {
        private static int CurrentValue { get; set; } = 1;

         public static int Next()
         {
            return CurrentValue++;
         }       
    }
}

