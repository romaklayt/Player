using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Player
{   [Serializable]
    public class Album
    {
        public Album()
        {

        }
        public string Title { get; set; }
        [XmlIgnore]
        public List<Song> Songs { get; set; }
        [XmlIgnore]
        public Artist Artist { get; set; }
    }
}
