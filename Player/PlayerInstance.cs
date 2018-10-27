using System;
using System.Collections.Generic;
using System.Linq;
using Player.Skins;

namespace Player
{
    public class PlayerInstance
    {
        private Skin skin;
        private int _volume;

        public bool Locked { get; set; }

        public bool Playing { get; set; }

        public Song PlayingSong { get; set; }

        public List<Song> Songs { get; set; }
        
        

        public PlayerInstance(Skin skinUser)
        {
            switch (skinUser)
            {
                case AllCaps caps:
                    skin=caps;
                    break;
                case ClassicSkin clas:
                    skin = clas;
                    break;
                case ColorSkin csColorSkin:
                    skin=csColorSkin;
                    break;
                case ColorSkin2 csColorSkin2:
                    skin=csColorSkin2;
                    break; 
            }
        }

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

        public void Filter(Genres genre)
        {
            var filteredSongs = new List<Song>();

            foreach (var song in this.Songs)
            {
                if ((song.Genre & genre) == genre)
                {
                    filteredSongs.Add(song);
                }
            }

            this.Songs = filteredSongs;
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
                        skin.Clear();
                        PlayingSong = song;

                        
                        ListSongs();
                        skin.Render(PlayingSong.Title + ": " + PlayingSong.Lyrics);

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
                var songInfo = $"{data.title} - {data.duration.min}:{data.duration.sec}";
                if (data.isPlayingNow)
                {
                    songInfo = $"***{songInfo}***";
                }

                if (data.like.HasValue)
                {
                    if (data.like.Value)
                    {
                        
                        skin.Render(songInfo);
                       
                    }
                    else
                    {
                        
                        skin.Render(songInfo);
                       
                    }
                }
                else
                {
                    skin.Render(songInfo);
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
            List<Song> suffledSongs = new List<Song>();
            int step = 3;
            for (int i = 0; i < step; i++)
            {
                int index = i;

                while(index < Songs.Count)
                {
                    suffledSongs.Add(Songs[index]);
                    index += step;
                }
            }

            Songs = suffledSongs;
        }

        public void SortByTitle()
        {
            List<string> names = new List<string>();
            List<Song> sorted = new List<Song>();

            foreach (var song in Songs)
            {
                names.Add(song.Title);
            }

            names.Sort();

            foreach (var name in names)
            {
                foreach (var song in Songs)
                {
                    if (song.Title == name)
                    {
                        sorted.Add(song);
                        continue;
                    }
                }
            }

            Songs = sorted;
        }
    }
}
