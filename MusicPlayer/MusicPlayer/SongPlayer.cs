using System;
using System.Collections.Generic;

namespace MusicPlayer
{
    public class SongPlayer
    { 
        List<Songs> songsList = new List<Songs>();

        public void AddSongs(Songs song)
        {
            songsList.Add(song);
        }

        public void RemoveSong(Songs song)
        {
            songsList.Remove(song);
        }

        public void DisplaySongs()
        {
            foreach (Songs song in songsList)
            {
                Console.WriteLine($"Song Name: {song.SongName} Artist: {song.Artist}");
                
            }
        }
    }
}
