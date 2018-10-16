namespace Player
{
    public static class StringExtension
    {
        public static string Cut(this string title, int uncut)
        {
            title = title.Remove(uncut);
            title += "...";
            return title;
        }
    }
}