using System;
using GenericPlayer;

namespace Player
{   [Serializable]
    public class Song:Item 
    {
        public Song()
        {

        }
        public Song(string title = "Unknown", string lirycs = "Unknown", int duration = 0):base(title,duration)
        {
            this.Lyrics = lirycs;
        }


        public string Lyrics { get; set; }
    
        public Artist Artist { get; set; }

        public Album Album { get; set; }
    }
}