using System.Collections.Generic;
using GenericPlayer;

namespace Player
{
    public class Album
    {
        public string Title { get; set; }

        public List<Item> Items { get; set; }

        public Artist Artist { get; set; }
    }
}
