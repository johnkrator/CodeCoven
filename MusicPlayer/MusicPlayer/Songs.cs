namespace MusicPlayer
{
    public class Songs
    {
        public string Id { get; set; }
        public string SongName { get; set; }
        public string Artist { get; set; }

        public Songs(string id, string songName, string artist)
        {
            Id = id;
            SongName = songName;
            Artist = artist;
        }
    }
}
