using System;

namespace Player.Skins
{
    internal class ColorSkin : Skin
    {
        private readonly ConsoleColor color;

        public ColorSkin(ConsoleColor color)
        {
            this.color = color;
        }

        public override void Clear()
        {
            Console.Clear();
        }

        public override void Render(string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}