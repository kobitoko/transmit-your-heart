using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    Vector3Int position;
    GridScript gridScript;

    public void setGridScript(GridScript _gridScript)
    {
        gridScript = _gridScript;
    }

    public void setPosition(Vector3Int _position)
    {
        position = _position;
        gameObject.transform.position = gridScript.cellToWorldPostition(_position);
    }
}
