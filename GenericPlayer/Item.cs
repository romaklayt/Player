namespace GenericPlayer
{
    public  class Item
    {
        public Item(string title = "Unknown", int duration = 0)
        {
            this.Title = title;
            this.Duration = duration;
        }

        public string Title { get; set; }

        public int Duration { get; set; }

        public bool? Like { get; set; }

        public Enums.Genres Genre { get; set; }

        public void LikeSong()
        {
            Like = true;
        }

        public void DislikeSong()
        {
            Like = false;
        }
    }
}
