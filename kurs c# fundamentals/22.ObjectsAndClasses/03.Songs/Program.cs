﻿
internal class Program
{

    class Song
    {
        public string TypeList;
        public string Name;
        public string Time;

    }

    static void Main(string[] args)
    {
        int numOfSongs = int.Parse(Console.ReadLine());

        List<Song> songs = new List<Song>();

        for (int i = 0; i < numOfSongs; i++)
        {
            string[] data = Console.ReadLine().Split("_");

            string type = data[0];
            string name = data[1];
            string time = data[2];

            Song song = new Song();

            song.TypeList = type;
            song.Name = name;
            song.Time = time;

            songs.Add(song);
        }

        string typeList = Console.ReadLine();

        if (typeList  == "all")
        {
            foreach (Song song in songs)
            {
                Console.WriteLine(song.Name);
            }
        }
        else 
        {
            List<Song> filtered = songs.Where(s => s.TypeList == typeList)
                .ToList();

            foreach (Song song in filtered)
            {
                Console.WriteLine(song.Name);
            }

        }
    }
}
