using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour {
    public float speed = 5;
    float originalSpeed;
    Vector3Int position;
    GridScript gridScript;

    public void Start()
    {
        originalSpeed = speed;
    }

    /**
     * Sets the new speed of the player. Special value: -1 means reset speed to the original speed.
     */
    public void setSpeed(int newSpeed)
    {
        // Special case, -1 means reset speed.
        if(newSpeed == -1)
        {
            speed = originalSpeed;
            return;
        }
        this.speed = newSpeed;
    }

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
        Vector2 inputMovement = tileDetect(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        Vector3 newPosition = this.gameObject.GetComponent<Transform>().position;
        newPosition.x += inputMovement.x * speed * Time.deltaTime;
        newPosition.y += inputMovement.y * speed * Time.deltaTime;
        this.gameObject.GetComponent<Transform>().position = newPosition;
    }

    // Checks if there is a tile ahead of the movement and disables movement if there is.
    Vector2 tileDetect(Vector2 movement)
    {
        float x = movement.x;
        float y = movement.y;
        // If no movement, nothing happens.
        if(Mathf.Approximately(x, 0f) && Mathf.Approximately(y,0))
        {
            return Vector2.zero;
        }
        Vector2 currentDirection = new Vector2(x, y);
        float dist = 0.3f;
        // Diagonal is a bit further away since it is not directly at the character.
        if (!Mathf.Approximately(x, 0f) && !Mathf.Approximately(y, 0))
        {
            dist = 0.6f;
        }
        // Test for a solid tile in that direction.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, currentDirection, dist);
        #if (UNITY_EDITOR)
            Debug.DrawRay(transform.position, currentDirection, Color.red);
        #endif
        // A solid tile was found, don't allow movement to that direction.
        if (hit.collider != null && hit.collider.GetComponent<TilemapCollider2D>() != null) {
            return Vector2.zero;
        }
        // if nothing found return original movement.
        return movement;
    }
}
