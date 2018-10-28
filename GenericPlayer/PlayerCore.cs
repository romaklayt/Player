using System;
using System.Collections.Generic;
using System.Linq;
using GenericPlayer.Enums;
namespace GenericPlayer
{
    public abstract class PlayerCore<T> where T:Item
    {
        private int _volume;

        public bool Locked { get; set; }

        public bool Playing { get; set; }

        public T PlayingItem { get; set; }

        public List<Item> Items { get; set; }
        
        
        public int Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (value < 0) _volume = 0;
                else if (value > 100) _volume = 100;
                else _volume = value;
            }
        }        

        public void VolumeUp()
        {
            //Volume++;
            Volume = Volume + 1;
        }

        public void VolumeDown()
        {
            //Volume--;
            Volume = Volume - 1;
        }

        public void VolumeChange(int step)
        {
            //Volume--;
            Volume += step;
        }

        public void Add(params T[] items)
        {
            Items = new List<Item>(items.ToList());
        }

        public void Add(Playlist<T> playlist)
        {
            Items = new List<Item>(playlist.Items);
        }
        

        public void Filter(GenericPlayer.Enums.Genres genre)
        {
            var filtredItems = new List<T>();

            foreach (T item in this.Items)
            {
                if ((item.Genre & genre) == genre)
                {
                    filtredItems.Add(item);
                }
            }

            this.Items = new List<Item>(filtredItems);
        }

     //   public abstract bool Play<T>(out T playingSong, bool loop = false);
        
        public bool Stop(out T playingItem)
        {
            playingItem = PlayingItem;

            if (Locked == false)
            {
                Playing = false;
            }

            return Playing;
        }

        public bool Lock()
        {
            return Locked = true;
        }

        public bool Unlock()
        {
            return Locked = false;
        }

        public void Shuffle()
        {
            Items.Shuffle();
        }

        public void SortByTitle()
        {
            Items.SortEX();
        }
    }
}
