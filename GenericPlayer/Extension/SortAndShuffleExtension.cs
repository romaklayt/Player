using System.Collections.Generic;
namespace GenericPlayer
{
    public static class SortExtension
    {
        public static List<T> SortEX<T>(this List<T> items) where T:Item
        {
            var names = new List<string>();
            var sorted = new List<T>();
            foreach (var item in items) names.Add(item.Title);
            names.Sort();
            foreach (var name in names)
            foreach (var item in items)
                if (item.Title == name)
                {
                    sorted.Add(item);
                }
            items = sorted;
            return items;
        }
    }
    public static class ShuffleExtension 
    {
        public static List<T> Shuffle<T>(this List<T> items) where T:Item
        {
            var suffledSongs = new List<T>();
            var step = 3;
            for (var i = 0; i < step; i++)
            {
                var index = i;
                while (index < items.Count)
                {
                    suffledSongs.Add(items[index]);
                    index += step;
                }
            }
            items = suffledSongs;
            return items;
        }
    }
} 