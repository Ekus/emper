﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyWebsite
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRemoteControl" in both code and config file together.
    public interface IMediaPlayer
    {
        Album[] GetAlbums();

        void PlayAlbum(string albumTitle);

        void PlaySong(string albumTitle, string songTitle);

        void Play();

        void Pause();

        PlayerState GetState();
    }


    public class Album
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public List<Song> Songs { get; private set; }
        public string Image { get; set; }
        public string Author { get; set; }

        public Album()
        {
            Songs = new List<Song>();
        }
    }

    public class Song
    {
        public string Title { get; set; }
        public Album Album { get; set; }
        // public TimeSpan Length { get; set; }
        public string FilePath { get; set; }
    }

    public class PlayerState
    {
        public string AlbumTitle { get; set; }
        public string SongTitle { get; set; }
        public TimeSpan Position { get; set; }
        public bool IsPlaying { get; set; }
    }
}
