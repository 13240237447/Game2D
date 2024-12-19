using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapTest : MonoBehaviour
{
    private Tilemap _tilemap;

    private void Awake()
    {
        _tilemap = GetComponent<Tilemap>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
