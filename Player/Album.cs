using System.Collections.Generic;

namespace Player
{
    public class Album
    {
        public string Title { get; set; }

        public List<Song> Songs { get; set; }

        public Artist Artist { get; set; }
    }
}
