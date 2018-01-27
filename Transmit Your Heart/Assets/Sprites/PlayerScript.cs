using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float speed = 5;
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
    public void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 newPosition = this.gameObject.GetComponent<Transform>().position;
        newPosition.x += h * speed * Time.deltaTime;
        newPosition.y += v * speed * Time.deltaTime;
        this.gameObject.GetComponent<Transform>().position = newPosition;
    }
}
