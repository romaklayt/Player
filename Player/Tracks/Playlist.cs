using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class Playlist
    {
        public List<Song> Songs { get; set; }

        public void Add(params Song[] songs)
        {
            Songs = songs.ToList<Song>();
        }
    }
}
