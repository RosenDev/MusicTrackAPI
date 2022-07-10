using System;
namespace MusicTrackAPI.Data.Domain
{
	public class User: MySqlEntity
	{
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

    }
}

