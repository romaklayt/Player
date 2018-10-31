using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPlayer
{   [Serializable]
    public class Playlist<T>
    {   
        public List<T> Items { get; set; }

        public void Add(params T[] items)
        {
            Items = items.ToList<T>();
        }
    }
}
