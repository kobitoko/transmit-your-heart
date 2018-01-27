using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridScript : MonoBehaviour
{
    public GameObject playerObject;
    public Vector3Int playerStartPosition;
    PlayerScript playerScript;
    Grid grid;
    Tilemap tilemap;

    void Start()
    {
        grid = GetComponent<Grid>();
        tilemap = grid.GetComponentInChildren<Tilemap>();
        playerScript = playerObject.GetComponent<PlayerScript>();
        playerScript.setGridScript(this);
        playerScript.setPosition(playerStartPosition);
    }

    //gives the position of the center of the tile
    public Vector3 cellToWorldPostition (Vector3Int _position)
    {
        return grid.CellToWorld(_position) + grid.cellSize/2.0f;
    } 
}
