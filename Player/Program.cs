﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using GenericPlayer.Enums;
using Player.Skins;
using GenericPlayer;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            //VolumeExample();
            //AddOverloadingExample();
            //SortAndShuffleExample();

            ClassicUsagePlayerExample();
            //LoadPlaylist();
            
            Console.ReadLine();
 
        }

        private static void SaveAsPlaylist(Playlist<Song> songs)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Playlist<Song>));
            SerializeSongs(songs, xmlSerializer);
            Console.WriteLine("Save playlist");
        }
        private static void LoadPlaylist()
        {
            var player = new PlayerInstance<Song>(new ColorSkin2());

            Song currentPlayingSong = null;
            Song[] newSongs = null;
            Album album = null;
            Artist artist = null;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Song[]));
            newSongs = DeserializeSongs(xmlSerializer);
            player.Add(newSongs);
            player.Play(out currentPlayingSong);
        }
        private static void ClassicUsagePlayerExample()
        {
            var player = new PlayerInstance<Song>(new ColorSkin2());

            Song currentPlayingSong = null;
            Song[] songs = null;
            Album album = null;
            Artist artist = null;
            
            CreatePlayerItems(out songs, out artist, out album);
            var playlist = new Playlist<Song>() {Items = new List<Song>(songs)}; 
            player.Add(playlist);
            SaveAsPlaylist(playlist);
            //player.Add(songs);
            player.Play(out currentPlayingSong);
        }
        private static Song[] DeserializeSongs(XmlSerializer xmlSerializer)
        {
            Song[] songs;
            using (FileStream fs = new FileStream("songs.xml", FileMode.OpenOrCreate))
            {
                songs = (Song[])xmlSerializer.Deserialize(fs);
            }
            return songs;
        }

        private static void SerializeSongs(Playlist<Song> songs, XmlSerializer xmlSerializer)
        {
            
            using (FileStream fs = new FileStream("songs.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, songs);
            }
        }

        private static void AddOverloadingExample()
        {
            Song currentPlayingSong = null;
            Song[] songs = null;
            Album album = null;
            Artist artist = null;

            var player = new PlayerInstance<Song>(new ColorSkin2());
            CreatePlayerItems(out songs, out artist, out album);

            Console.WriteLine("-- Playing Album --");
            player.Add(album);
            Console.WriteLine(player.Play(out currentPlayingSong));

            Console.WriteLine("-- Playing Artist --");
            player.Add(artist);
            Console.WriteLine(player.Play(out currentPlayingSong));
        }

        private static void SortAndShuffleExample()
        {
            var player = new PlayerInstance<Song>(new ColorSkin2());

            Song currentPlayingSong = null;
            Song[] songs = null;
            Album album = null;
            Artist artist = null;

            CreatePlayerItems(out songs, out artist, out album);
            player.Add(songs);

            Console.WriteLine("-- Playing Songs --");
            System.Threading.Thread.Sleep(3000);            
            player.Play(out currentPlayingSong);

            Console.WriteLine("-- Suffle Songs --");
            System.Threading.Thread.Sleep(3000);
            player.Shuffle();
            player.Play(out currentPlayingSong);

            Console.WriteLine("-- Sort Songs --");
            System.Threading.Thread.Sleep(3000);
            player.SortByTitle();
            player.Play(out currentPlayingSong);
        }

        private static void VolumeExample()
        {
            var player = new PlayerInstance<Song>(new ColorSkin2());

            Console.WriteLine(player.Volume);

            player.Volume = 300;
            player.VolumeUp();
            player.VolumeUp();
            player.VolumeUp();

            player.VolumeChange(int.Parse(Console.ReadLine()));

            Console.WriteLine(player.Volume);
        }

        private static void CreatePlayerItems(out Song[] songs, out Artist artist, out Album album)
        {
            artist = new Artist() { Name = "Loboda", Items = new List<Item>(), Albums = new Album[1] };
            album = new Album() { Artist = artist, Title = "Superstar", Items = new List<Item>() };
            songs = CreateSongs(artist, album);

            artist.Albums[0] = album;

            artist.Items = new List<Item>() { songs[0], songs[2], songs[4] };
            album.Items = new List<Item>() { songs[1], songs[3], songs[4] };

            songs[0].Like = true;
            songs[3].Like = false;
            songs[4].Like = true;
        }

        private static Song[] CreateSongs(Artist artist, Album album)
        {
            return new Song[] {
                new Song()
                {
                    Title = "Superstar(1)",
                    Duration = 300,
                    Lyrics = @"Для тебя не осталось слов и мыслей хороших...",
                    Album = album,
                    Artist = artist,
                    Genre = Genres.Pop /*0001*/ | Genres.Rock /*0010*/ //0011
                },
                new Song()
                {
                    Title = "Твои глаза(5)",
                    Duration = 300,
                    Lyrics = @"Твои глаза... останови планету...",
                     Album = album,
                    Artist = artist,
                    Genre = Genres.Rock
                },
                new Song()
                {
                    Title = "К черту любовь(2)",
                    Duration = 300,
                    Lyrics = @"А может к черту любовь... все понимаю но я опять влюбляюсь в тебя",
 Album = album,
                    Artist = artist
                },
                new Song()
                {
                    Title = "Парень(3)",
                    Duration = 300,
                    Lyrics = @"Парень, ты меня так сильно ранил...",
 Album = album,
                    Artist = artist
                },
                new Song()    {
                    Title = "Случайная(4)",
                    Duration = 300,
                    Lyrics = @"Ты пишешь мне письма такие печальные...",
 Album = album,
                    Artist = artist
                }
            };
        }
    }
}
