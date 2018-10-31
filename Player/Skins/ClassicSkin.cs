using System;

namespace Player.Skins
{
    internal class ClassicSkin : ISkin
    {
        public  void Clear()
        {
            Console.Clear();
        }

        public  void Render(string text)
        {
            Console.WriteLine(text);
        }
    }
}