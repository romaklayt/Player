using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Skins
{
    class AllCaps:Skin
    {
        public override void Clear()
        {
            Console.Clear();
        }

        public override void Render(string text)
        {
            Console.WriteLine(text.ToUpper());
        }
    }
}
