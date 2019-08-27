using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberSongs = int.Parse(Console.ReadLine());

            Song song = new Song();
            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberSongs; i++)
            {
                List<string> data = Console.ReadLine().Split("_").ToList();
                string type = data[0];
                string name = data[1];
                string time = data[2];

                song.AddSongs(type, name, time, songs);
            }

            string typeList = Console.ReadLine();

            PrintSongs(song, songs, typeList);

        }

        private static void PrintSongs(Song song, List<Song> songs, string typeList)
        {
            if (typeList == "all")
            {
                foreach (Song file in songs)
                {
                    Console.WriteLine(file.name);
                }
            }
            else
            {
                foreach (Song file in song.TypeSongs(typeList, songs))
                {
                    Console.WriteLine(file.name);
                }
            }
        }
    }
    class Song
    {

        public string typeList { get; set; }
        public string name { get; set; }
        public string time { get; set; }


        public void AddSongs(string type, string name, string time, List<Song> songs)
        {
            Song song = new Song();
            song.typeList = type;
            song.name = name;
            song.time = time;
            songs.Add(song);

        }

        public List<Song> TypeSongs(string typelist, List<Song> songs)
        {
            List<Song> typesongs = songs.Where(song => song.typeList == typelist).ToList();
            return typesongs;
        }
    }







}


