using System;

namespace MusicPlayer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SongPlayer songPlayer = new SongPlayer();
            int userInput = 0;
            do
            {
                Console.WriteLine("Please choose an option\n1. Add a Song\n2. Remove a song\n3. Create a playlist\n4. Display all songs\n5. Exit");

                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Enter SongName");
                        string songName = Console.ReadLine();
                        Console.WriteLine("Enter Name of Artist");
                        string artist = Console.ReadLine();

                        Songs song = new Songs(songName, artist);
                        
                        songPlayer.AddSongs(song);
                        break;
                    case 2:
                        Console.WriteLine("Remove a song");
                        string songTitle = Console.ReadLine();

                        // Songs songList = new Songs(songTitle);
                        // songPlayer.RemoveSong(songTitle);
                        break;
                    case 3:
                        break;
                    case 4:
                        songPlayer.DisplaySongs();
                        break;
                }
                
            } while (userInput != 5);
        }
    }
}
