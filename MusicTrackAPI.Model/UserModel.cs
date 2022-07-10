using System;
namespace MusicTrackAPI.Model
{
    public class UserModel: ApiEntity
	{
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}

