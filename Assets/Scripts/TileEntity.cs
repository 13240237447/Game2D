using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[Flags]
public enum ETileTag
{
    None = 0,
    [InspectorName("可以通过")]
    CanPass =  1,
    
}

[Flags]
public enum ETileNeighbor
{
    None          =  0,
    Up            =  1,
    Down          =  1 << 1,
    Left          =  1 << 2,
    Right         =  1 << 3,
    UpLeft        =  1 << 4,
    UpRight       =  1 << 5,
    DownLeft      =  1 << 6,
    DownRight     =  1 << 7,
}

public class TileEntity : TileBase
{

    [SerializeField]
    private ETileTag tileTag;

    public ETileNeighbor TileNeighbor { private set; get; } = ETileNeighbor.None;

    public ETileTag TileTag => tileTag;
    
    public void AddNeighbor(ETileNeighbor neighbor)
    {
        TileNeighbor |= neighbor;
    }
    
    public void AddTag(ETileTag tag)
    {
        var oldTag = tileTag;
        tileTag = (oldTag | tag);
        OnTagChange(oldTag, tileTag);
        Game.ET.BroadEvent(new OnTileTagChange(this,oldTag,tileTag));
    }

    public void RemoveTag(ETileTag tag)
    {
        var oldTag = tileTag;
        tileTag = (oldTag & ~tag);
        OnTagChange(oldTag, tileTag);
        Game.ET.BroadEvent(new OnTileTagChange(this,oldTag,tileTag));
    }

    protected virtual void OnTagChange(ETileTag oldTag,ETileTag newTag)
    {
        
    }
    
}