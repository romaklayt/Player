using System.Collections.Generic;

namespace Player
{
    public static class SortExtension
    {
        public static List<Song> SortEX(this List<Song> Songs)
        {
            var names = new List<string>();
            var sorted = new List<Song>();

            foreach (var song in Songs) names.Add(song.Title);

            names.Sort();

            foreach (var name in names)
            foreach (var song in Songs)
                if (song.Title == name)
                {
                    sorted.Add(song);
                }

            Songs = sorted;
            return Songs;
        }
    }

    public static class ShuffleExtension
    {
        public static List<Song> Shuffle(this List<Song> Songs)
        {
            var suffledSongs = new List<Song>();
            var step = 3;
            for (var i = 0; i < step; i++)
            {
                var index = i;

                while (index < Songs.Count)
                {
                    suffledSongs.Add(Songs[index]);
                    index += step;
                }
            }

            Songs = suffledSongs;
            return Songs;
        }
    }
}