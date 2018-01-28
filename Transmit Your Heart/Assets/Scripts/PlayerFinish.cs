using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerFinish : MonoBehaviour
{
    public float walkSpeed = 5;

    float originalSpeed;
    Vector3Int position;
    GridScript gridScript;
    GameObject staffNotes;
    bool tuneOver;

    public List<Vector2> pathToWalk = new List<Vector2>(5);

    public void Start()
    {

    }

    /**
     * Sets the new speed of the player. Special value: -1 means reset speed to the original speed.
     */
    public void setSpeed(int newSpeed)
    {
        // Special case, -1 means reset speed.
        if (newSpeed == -1)
        {
            walkSpeed = originalSpeed;
            return;
        }
        this.walkSpeed = newSpeed;
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
        gameObject.GetComponent<SonarPingScript>().playPing();
        if (tuneOver == true)
        {
            Vector2 inputMovement = tileDetect(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            inputMovement = Vector3.Normalize(inputMovement);
            Vector3 newPosition = this.gameObject.GetComponent<Transform>().position;
            newPosition.x += inputMovement.x * walkSpeed * Time.deltaTime;
            newPosition.y += inputMovement.y * walkSpeed * Time.deltaTime;
            this.gameObject.GetComponent<Transform>().position = newPosition;
            // Colors!
            gameObject.GetComponent<SonarPingScript>().changePingColor(Color.blue);
            gameObject.GetComponent<SonarPingScript>().changePingSpeed(1);
            gameObject.GetComponent<SonarPingScript>().changePingSize(1);
        }
        StartCoroutine(findBestFriend());
        if (pathToWalk.Count > 0 && tuneOver == false)
        {
            gameObject.GetComponent<Transform>().position = Vector2.MoveTowards(transform.position, pathToWalk[0], 1.5f * Time.deltaTime);
            if (Vector2.Distance(transform.position, pathToWalk[0]) < 0.3f && pathToWalk.Count > 0)
            {
                pathToWalk.RemoveAt(0);
                gameObject.GetComponent<SonarPingScript>().changePingColor(Random.ColorHSV(0f, 1f, 0.8f, 1f, 0.6f, 1f));
                gameObject.GetComponent<SonarPingScript>().changePingSpeed(Random.Range(0.8f, 1.5f));
                gameObject.GetComponent<SonarPingScript>().changePingSize(Random.Range(0.8f, 1.3f));
            }
        }
    }

    // Help fix friendo
    IEnumerator findBestFriend()
    {
        yield return new WaitForSeconds(22);
        Debug.Log("Found a friend on the same wavelength, FRIEND!");
        tuneOver = true;
        // Friend arrive!
        
        // Free roam
        yield return new WaitForSeconds(4);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>().fadeSpeed = 0.5f;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>().fadeOut();
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
        if (Mathf.Approximately(x, 0f) && Mathf.Approximately(y, 0))
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
            dist = radius * 1.5f + 0.1f;
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

        // A solid tile was found, don't allow movement to that direction.
        if (hit.collider != null && hit.collider.GetComponent<TilemapCollider2D>() != null)
        {
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
        if (position.x > (cameraPosition.x + halfWidth) ||
            position.x < (cameraPosition.x - halfWidth) ||
            position.y > (cameraPosition.y + halfHeight)||
            position.y < (cameraPosition.y - halfHeight))
        {
            return false;
        }
        return true;
    }
}
