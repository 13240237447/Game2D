using System;
using System.Collections.Generic;
using Manager;

public static class Game
{
    public static EventManager ET { private set; get; }

    private static Dictionary<Type, IManager> mgrs = new();
    
    public static ResourceManager Res { set; get; }

}