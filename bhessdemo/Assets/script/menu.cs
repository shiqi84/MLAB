using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class menu
{
    [MenuItem("Tools/Assign Tile script")]
    public static void AssignTileScript()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("tile");

        foreach (GameObject t in tiles)
        {
            t.AddComponent<tile>();
        }
    }

    [MenuItem("Tools/Assign Tile 2D collider")]
    public static void AssignTileCollider()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("tile");

        foreach (GameObject t in tiles)
        {  
            t.AddComponent<BoxCollider2D>();
        }
    }
}

