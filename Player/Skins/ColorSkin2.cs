using System;

namespace Player.Skins
{
    internal class ColorSkin2 : ISkin
    {
        private readonly Random rand = new Random();

        public  void Clear()
        {
            Console.Clear();
            var j = 30;
            var sym = (char) 0xD6;
            for (var i = 0; i < j; i++) Console.Write(sym);
            Console.WriteLine();
        }

        public  void Render(string text)
        {
            var color = rand.Next(1, 15);
            Console.ForegroundColor = (ConsoleColor) color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}