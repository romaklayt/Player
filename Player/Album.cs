using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using GenericPlayer;

namespace Player
{   [Serializable]
    public class Album
    {
        public Album()
        {

        }
        public string Title { get; set; }
        [XmlIgnore]
        public List<Item> Items { get; set; }
        [XmlIgnore]
        public Artist Artist { get; set; }
    }
}
