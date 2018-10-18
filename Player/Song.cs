namespace Player
{
    public class Song
    {
        public Song(string title = "Unknown", string lirycs = "Unknown", int duration = 0)
        {
            this.Title = title;
            this.Lyrics = lirycs;
            this.Duration = duration;
        }

        public string Title { get; set; }

        public string Lyrics { get; set; }

        public int Duration { get; set; }

        public Artist Artist { get; set; }

        public Album Album { get; set; }

        public bool? Like { get; set; }
        public Genres genre;

        //public System.Nullable<bool> Like { get; set; }

        public void LikeSong()
        {
            Like = true;
        }

        public void DislikeSong()
        {
            Like = false;
        }

        public void Deconstruct(out string Artist, out string Title,out  string Lyrics,out int Duration,out string Album,out bool? Like)
        {
            Title = this.Title;
            Lyrics = this.Lyrics;
            Duration = this.Duration;
            Artist = this.Artist.Name;
            Album = this.Album.Title;
            Like = this.Like;
        }
    }
}
