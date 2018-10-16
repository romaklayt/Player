using System;
using System.Collections.Generic;
using System.Linq;

namespace Player
{
    public class PlayerInstance
    {
        private int _volume;

        public bool Locked { get; set; }

        public bool Playing { get; set; }

        public Song PlayingSong { get; set; }

        public List<Song> Songs { get; set; }        

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

        public void Add(params Song[] songs)
        {
            Songs = songs.ToList();
        }

        public void Add(Playlist playlist)
        {
            Songs = playlist.Songs;
        }

        public void Add(Album album)
        {
            Songs = album.Songs;
        }

        public void Add(Artist artist)
        {
            Songs = artist.Songs;
        }

        public bool Play(out Song playingSong, bool loop = false)
        {
            playingSong = PlayingSong = PlayingSong ?? Songs[0];

            if (!Locked)
            {
                Playing = true;
            }

            if (Playing)
            {
                int cycles = loop ? 5 : 1;
                for (int i = 0; i < cycles; i++)
                {
                    foreach (var song in Songs)
                    {
                        PlayingSong = song;

                        Console.Clear();

                        ListSongs();
                        Console.WriteLine(PlayingSong.Title + ": " + PlayingSong.Lyrics);

                        System.Threading.Thread.Sleep(2000);
                    }
                }
            }

            return Playing;
        }

        private void ListSongs()
        {
            foreach (var song in Songs)
            {
                var data = GetSongData(song);
                var songInfo = $"{data.title.Cut(3)} - {data.duration.min}:{data.duration.sec}";
                if (data.isPlayingNow)
                {
                    songInfo = $"***{songInfo}***";
                }

                if (data.like.HasValue)
                {
                    if (data.like.Value)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(songInfo);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(songInfo);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine(songInfo);
                }                 
            }
        }

        private (string title, (int min, int sec) duration, bool isPlayingNow, bool? like) GetSongData(Song song)
        {
            var title = song.Title;
            var isPlayingNow = song == PlayingSong;
            var min = song.Duration / 60;
            var sec = song.Duration % 60;
            
            return (title, (min, sec), isPlayingNow, song.Like);
        }

        /*private dynamic GetSongData(Song song)
        {
            var title = song.Title;
            var isPlayingNow = song == PlayingSong;
            var min = song.Duration / 60;
            var sec = song.Duration % 60;

            //return (title, (min, sec), isPlayingNow);

            return new
            {
                title,
                duration = new
                {
                    min,
                    sec
                },
                isPlayingNow                
            };
        }*/

        public bool Stop(out Song playingSong)
        {
            playingSong = PlayingSong;

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
            Songs.Shuffle();
        }

        public void SortByTitle()
        {
            Songs.SortEX();
        }
    }
}
