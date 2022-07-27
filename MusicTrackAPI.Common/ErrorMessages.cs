using System;
namespace MusicTrackAPI.Common
{
    public class ErrorMessages
    {
        public const string UseRegisterEnpoint = "Please use the register endpoint!";
        public const string UserDoesNotExist = "The user is not yet registered!";
        public const string UserAlreadyExist = "This user already exists!";
        public const string InvalidPassword = "Incorrect password!";
        public const string PlaylistPlayTimeExceedsTwoHours = "The total duration of the tracks in this playlist cannot exceed 2 hours.";
        public const string AlbumNotFound = "Album {id} does not exists.";
        public const string TrackNotFound = "Track {id} does not exists.";
        public const string PlaylistNotFound = "Playlist {id} does not exists.";
        public const string InvalidPosition = "The provided position is invalid! If you wish to add track istead of replacing one please use the AddTrack endpoint.";
        public const string PlaylistContainsNoTracks = "The playlist should contain at least 1 track.";
    }
}

