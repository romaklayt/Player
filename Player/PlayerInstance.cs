using System;
using System.Collections.Generic;
using System.Linq;
using GenericPlayer;
using Player.Skins;

namespace Player
{
    public class PlayerInstance<T>:GenericPlayer.PlayerCore<T> where T:Song
    {
        private Skin skin;
      

        public T PlayingSong { get; set; }

        
        

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
        
        
        public void Add(Album album)
        {
            Items = album.Items;
        }

        public void Add(Artist artist)
        {
            Items = artist.Items;
        }
        

        public  bool Play(out T playingSong, bool loop = false)
        {
            playingSong = (T) (PlayingSong = (T) (PlayingSong ?? Items[0]));

            if (!Locked)
            {
                Playing = true;
            }
            
            if (Playing)
            {
                int cycles = loop ? 5 : 1;
                for (int i = 0; i < cycles; i++)
                {
                    foreach (var song in Items)
                    {
                        skin.Clear();
                        PlayingSong = (T) song;

                        
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
            foreach (var song in Items)
            {
                var data = GetSongData(song as Song);
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

        
    }
}
