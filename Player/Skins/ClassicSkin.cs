using System;

namespace Player.Skins
{
    internal class ClassicSkin : Skin
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