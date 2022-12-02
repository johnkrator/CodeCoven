using System;

namespace MusicPlayer
{
    public class Display
    {
        public void DisplayOption()
        {
            SongPlayer songPlayer = new SongPlayer();
            int userInput = 0;

            do
            {
                Console.WriteLine(
                    "\nPlease select an option\n1. Add a Song\n2. Remove a song\n3. Create a playlist\n4. Display all songs\n5. Exit\n");

                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Console.Write("Enter song id: ");
                        string id = Console.ReadLine();
                        Console.Write("Enter SongName:  ");
                        string songName = Console.ReadLine();
                        Console.Write("Enter Name of Artist: ");
                        string artist = Console.ReadLine();

                        Songs song = new Songs(id, songName, artist);

                        songPlayer.AddSongs(song);
                        break;
                    case 2:
                        // songPlayer.RemoveSong();
                        break;
                    case 3:
                        break;
                    case 4:
                        songPlayer.DisplaySongs();
                        break;
                }
            } while (userInput != 5);
        }

        public void Run()
        {
            DisplayOption();
        }
    }
}
