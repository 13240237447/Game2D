using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTest : MonoBehaviour
{
    private Tilemap _tilemap;

    private void Awake()
    {
        _tilemap = GetComponent<Tilemap>();

        foreach (var tile in _tilemap.GetTiles<TileBase>())
        {
            Debug.Log($"{tile.name}");
        }
    }
}