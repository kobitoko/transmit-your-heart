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
        // Movement
        Vector2 inputMovement = tileDetect(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        inputMovement = Vector3.Normalize(inputMovement);
        Vector3 newPosition = this.gameObject.GetComponent<Transform>().position;
        newPosition.x += inputMovement.x * speed * Time.deltaTime;
        newPosition.y += inputMovement.y * speed * Time.deltaTime;
        this.gameObject.GetComponent<Transform>().position = newPosition;
        // Action
        if(Input.GetButtonDown("Action"))
        {
            Debug.Log("HELLO FREND");
        }
    }

    /**
     * Checks if there is a tile ahead of the movement and disables movement if there is.
     * Also disables movement to outside the camera.
     */
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
        float radius = gameObject.GetComponent<CircleCollider2D>().radius;
        // Always slightly bigger than the collider.
        float dist = radius + 0.1f;
        // Diagonal is a bit further away since it is not directly at the character.
        if (!Mathf.Approximately(x, 0f) && !Mathf.Approximately(y, 0))
        {
            dist = radius*1.5f + 0.1f;
        }
        // Test for being outside the camera
        if (!inCameraBounds(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) + (currentDirection * radius)))
        {
            return Vector2.zero;
        }
        // Offset the player's position by it's collider.
        Vector2 colliderPosition = gameObject.GetComponent<CircleCollider2D>().offset;
        Vector2 playerPosition = transform.position;
        // Test for a solid tile in that direction.
        RaycastHit2D hit = Physics2D.Raycast(colliderPosition + playerPosition, currentDirection, dist);
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

    // Checks if given point is within the camera.
    bool inCameraBounds(Vector2 position)
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        float aspect = Camera.main.GetComponent<Camera>().aspect;
        float halfHeight = Camera.main.GetComponent<Camera>().orthographicSize;
        float halfWidth = aspect * halfHeight;
        if( position.x > (cameraPosition.x + halfWidth) ||
            position.x < (cameraPosition.x - halfWidth) ||
            position.y > (cameraPosition.y + halfHeight) ||
            position.y < (cameraPosition.y - halfHeight))
        {
            return false;
        }
        return true;
    }



}
