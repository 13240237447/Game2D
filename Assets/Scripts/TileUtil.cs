using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TileUtil
{
    public static bool HasTag(this ETileTag @this, ETileTag tag)
    {
        return (@this & tag) == tag;
    }


    public static void InitTileGrid(Grid grid)
    {
        var tileEntity = grid.GetComponentsInChildren<TileEntity>();
        List<TileEntity> canReachEntities = new List<TileEntity>();
        foreach (var entity in tileEntity)
        {
            if (entity.TileTag.HasFlag(ETileTag.CanPass))
            {
                canReachEntities.Add(entity);
            }
        }
    }
    
    public static T[] GetTiles<T>(this Tilemap tilemap) where T : TileBase
    {
        List<T> tiles = new List<T>();
        
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {   
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            if (tilemap.HasTile(localPlace))
            {
               var tile =  tilemap.GetTile(localPlace) as T;
               if (tile != null)
               {
                   tiles.Add(tile);
               }
            }
        }
        return tiles.ToArray();
    }
}