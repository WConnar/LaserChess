using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEditor;

public class MulticastScript : MonoBehaviour
{
    delegate void MultiDelegate();
    MultiDelegate myMultiDelegate;

    // Start is called before the first frame update
    void Start()
    {
       /* Tilemap tileMap = this.GetComponent<Tilemap>();
        Sprite tileSprite = Resources.Load("Board and Pieces/Tiles/pinksq") as Sprite;
        Tile tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = tileSprite;
        tileMap.setTile(new Vector3Int(1,1,0), tile);
        tileMap.RefreshAllTiles();*/
    }

    void PrepareMove()
    {

    }
}
