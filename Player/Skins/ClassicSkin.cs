using System;

namespace Player.Skins
{
    internal class ClassicSkin : Skin
    {
        public override void Clear()
        {
            Console.Clear();
        }

        public override void Render(string text)
        {
            Console.WriteLine(text);
        }
    }
}