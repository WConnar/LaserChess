using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{

    public Tilemap tilemap;
    public BoundsInt bounds;
    public TileBase[] allTiles;
    public Tile previous;
    public Vector3Int previouscoordinates;
    public LinkedList<Tile> possibleMoves;
    public LinkedList<Vector3Int> possibleCoords;

    // Start is called before the first frame update
    void Start()
    {
        possibleMoves = new LinkedList<Tile>();
        possibleCoords = new LinkedList<Vector3Int>();
        tilemap = GetComponent<Tilemap>();
        Debug.Log(tilemap.cellBounds);
        bounds = tilemap.cellBounds;
        allTiles = tilemap.GetTilesBlock(bounds);

        for(int x = 0; x < bounds.size.x; x++){
            for(int y = 0; y < bounds.size.y; y++){
                TileBase tile = allTiles[x + y * bounds.size.x];
                if(tile != null) {
                    //Debug.Log("x: " + x + " y: " + y + " tile: " + tile.name);
                }
                else{
                    //Debug.Log("x: " + x + " y: " + y + " tile: null");
                }
            }

        }
    }

    // Update is called once per frame
    Vector3Int getPosition(Vector3Int temp, int temp_i)
    {
        for(int i = 0; i < temp_i + 1; i++)
        {
            temp += Vector3Int.up;
        }
        return temp;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = tilemap.WorldToCell(pos);
            Tile tile = tilemap.GetTile<Tile>(coordinate);

            Debug.Log(tile);

            if(tile != null){
                if(tile.name.ToString().Equals("wpawn")){
                    previous = tile;
                    for(int i = 0; i < 2; i++)
                    {
                    //Vector3Int targetCoordinate = coordinate + Vector3Int.up;
                    Vector3Int targetCoordinate = getPosition(coordinate, i);
                    Sprite tileSprite = Resources.Load<Sprite>("Board and Pieces/pinksq");
                    Tile targetTile = ScriptableObject.CreateInstance<Tile>();
                    targetTile.sprite = tileSprite;
                    targetTile.name = "pinksq";
                    previouscoordinates = coordinate;
                    tilemap.SetTile(targetCoordinate, targetTile);
                    possibleMoves.AddLast(targetTile);
                    possibleCoords.AddLast(targetCoordinate);
                    }

                }
                if(tile.name.ToString().Equals("pinksq")){
                    Debug.Log(tile);

                    foreach(Vector3Int i in possibleCoords){
                        tilemap.SetTile(i, null);
                    }
                    
                    
                    tilemap.SetTile(coordinate, null);
                    tile.sprite = previous.sprite;
                    tile.name = previous.name;
                    tilemap.SetTile(coordinate, tile);
                    tilemap.SetTile(previouscoordinates, null);
                }
            }

            
        }
    }
}
