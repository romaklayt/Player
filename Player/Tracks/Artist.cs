using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class Artist
    {
        public Artist()
        {
        }

        public Artist(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public List<Song> Songs { get; set; }

        public Album[] Albums { get; set; }
    }
}
