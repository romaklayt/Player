using GenericPlayer;

namespace Player
{
    public class Song:Item 
    {
        public Song(string title = "Unknown", string lirycs = "Unknown", int duration = 0):base(title,duration)
        {
            this.Lyrics = lirycs;
        }


        public string Lyrics { get; set; }
    
        public Artist Artist { get; set; }

        public Album Album { get; set; }
    }
}