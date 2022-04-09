using System;
using GhostPlayer.Core;
using GhostPlayer.Playback;
using System.Collections.Generic;

namespace GhostPlayer.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Annoying header
            Console.WriteLine("The Console GUI is mostly used for testing purposes.");
            Console.WriteLine("Please use the Avalonia version of the app.\n");

            // Test the song library
            SongLibrary lib = new SongLibrary();
            Song s = new Song
            {
                Title = "Test",
                Path = "C:/Users/GhostNear/Desktop/V.mp3"
            };
            lib.AddSong(s);
            
            Song s1 = new Song
            {
                Title = "Test1",
                Path = "./test/test1.mp3"
            };
            lib.AddSong(s1);

            // Print the library's songs
            List<Song> l = lib.SongList;
            foreach(Song x in l)
            {
                Console.WriteLine("Title: " + x.Title);
                Console.WriteLine("Path: " + x.Path);
                Console.WriteLine("");
            }

            // Try to play a song
            AudioHandler player = new AudioHandler();
            player.AddToQueue(s);
            player.Play();
            Console.WriteLine("Playing: " + s.Title);
            Console.WriteLine("Use the space key to pause / unpause the audio playback.");

            // Wait for input
            while(true)
            {
                var ch = Console.ReadKey();
                if(ch.Key == ConsoleKey.Spacebar)
                {
                    if (player.isPaused)
                        player.Play();
                    else
                        player.Pause();
                }
            }
        }
    }
}
