using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Skins
{
    class AllCaps:ISkin
    {
        public  void Clear()
        {
            Console.Clear();
        }

        public  void Render(string text)
        {
            Console.WriteLine(text.ToUpper());
        }
    }
}
