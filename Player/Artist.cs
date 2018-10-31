using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Player
{   [Serializable]
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
        [XmlIgnore]
        public List<Song> Songs { get; set; }
        [XmlIgnore]
        public Album[] Albums { get; set; }
    }
}
