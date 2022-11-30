namespace MusicPlayer
{
    public class Songs
    {
        public string SongName { get; set; }
        public string Artist { get; set; }

        public Songs(string songName, string artist)
        {
            SongName = songName;
            Artist = artist;
        }
    }
}
