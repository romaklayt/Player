using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    [Flags]
    public enum Genres
    {
        None=0,
        Pop=1,
        House=2,
        Rock=4,
        Dance=8
    }
}
