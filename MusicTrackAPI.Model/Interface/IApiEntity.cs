﻿using System;
namespace MusicTrackAPI.Model.Interface
{
	public interface IApiEntity<TKey> where TKey: struct
	{
        TKey Id { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }
    }
}

