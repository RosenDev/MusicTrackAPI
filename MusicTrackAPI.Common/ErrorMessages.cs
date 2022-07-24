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
    }
}

