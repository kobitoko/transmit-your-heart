using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class GridScript : MonoBehaviour
{
    public GameObject playerObject;
    public Vector3Int playerStartPosition;
    PlayerScript playerScript;
    PlayerFinish playerFinish;
    Grid grid;
    Tilemap tilemap;

    void Start()
    {
        grid = GetComponent<Grid>();
        tilemap = grid.GetComponentInChildren<Tilemap>();
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            playerFinish = playerObject.GetComponent<PlayerFinish>();
            playerFinish.setGridScript(this);
            playerFinish.setPosition(playerStartPosition);
        }
        else
        {
            playerScript = playerObject.GetComponent<PlayerScript>();
            playerScript.setGridScript(this);
            playerScript.setPosition(playerStartPosition);
        }
    }

    //gives the position of the center of the tile
    public Vector3 cellToWorldPostition (Vector3Int _position)
    {
        return grid.CellToWorld(_position) + grid.cellSize/2.0f;
    } 
}
