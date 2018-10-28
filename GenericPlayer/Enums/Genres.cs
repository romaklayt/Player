using System;

namespace GenericPlayer.Enums
{
    [Flags]
    public enum Genres
    {
        None = 0,
        Pop = 1,        //0001
        Rock = 2,       //0010
        Metal = 4,      //0100
        Alternative = 8 //1000
    }
}
