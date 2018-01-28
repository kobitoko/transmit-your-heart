using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour
{
    public float walkSpeed = 5;
    public GameObject closestFriendPart = null;
    public int inventory = 0;

    float originalSpeed;
    Vector3Int position;
    GridScript gridScript;
    GameObject staffNotes;
    NotesInterface notesPlay;

    public void Start()
    {
        staffNotes = GameObject.FindGameObjectWithTag("staff");
        originalSpeed = walkSpeed;
        staffNotes.SetActive(false);
        notesPlay = GameObject.FindGameObjectWithTag("npc").GetComponent<NotesInterface>();
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
        // Movement only if not in rythm game mode.
        if (notesPlay.canPlaySong() == false)
        {
            Vector2 inputMovement = tileDetect(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            inputMovement = Vector3.Normalize(inputMovement);
            Vector3 newPosition = this.gameObject.GetComponent<Transform>().position;
            newPosition.x += inputMovement.x * walkSpeed * Time.deltaTime;
            newPosition.y += inputMovement.y * walkSpeed * Time.deltaTime;
            this.gameObject.GetComponent<Transform>().position = newPosition;
            // Action
            if (Input.GetButtonDown("Action") && closestFriendPart != null)
            {
                if (closestFriendPart.GetComponent<FriendoPartsScript>() != null)
                {
                    Debug.Log("HELLO FREND " + closestFriendPart.name);
                    // Rythm game sequence here.
                    StartCoroutine(pickupItemGame());
                }
                else if (closestFriendPart.GetComponent<FriendoScript>() != null && inventory == 3)
                {
                    StartCoroutine(fixFriend());
                }
            }
        }
        float halfHeight = Camera.main.GetComponent<Camera>().orthographicSize;
        if (transform.position.y > (Camera.main.transform.position.y + halfHeight + 1))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>().fadeOut();
        }
        //#if (UNITY_EDITOR)
        // Test next level skipping song.
        if (Input.GetKeyDown(KeyCode.Z))
        {
            int increase = notesPlay.getCurrentSong() + 1;
            if(increase > 4)
            {
                increase = 4;
            }
            notesPlay.setCurrentSong(increase);
        }
        //#endif
    }

    /**
     * begin is true if you start the song/rythm game, and false if you just end it.
     */
    NotesInterface beginRythmGame(bool begin)
    {

        staffNotes.SetActive(begin);
        if (begin == true)
        {
            notesPlay.playSong();
        }
        notesPlay.setCanPlaySong(begin);
        return notesPlay;
    }

    // Picking up the items for the friendo
    IEnumerator pickupItemGame()
    {
        // When the currentLevel increases in the music game it means they completed it.
        NotesInterface notesPlay = beginRythmGame(true);
        int before = notesPlay.getCurrentSong();
        yield return new WaitUntil(() => (before + 1) == notesPlay.getCurrentSong());
        beginRythmGame(false);
        inventory += 1;
        Debug.Log("CurrentSong: " + notesPlay.getCurrentSong());

        FriendoPartsScript friend = closestFriendPart.GetComponent<FriendoPartsScript>();
        friend.pickupItem();
    }

    // Help fix friendo
    IEnumerator fixFriend()
    {
        // CurrentLevel = 4 <- magic number for the music game. 4 = finish npc.
        beginRythmGame(true);
        notesPlay.setCurrentSong(4);
        yield return new WaitForSeconds(20);
        Debug.Log("For fixing me, THANK FRIEND!");
        beginRythmGame(false);
        // Follow frend, he show da wae
        closestFriendPart.GetComponent<FriendoScript>().gotFixed();
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
#if (UNITY_EDITOR)
        Debug.DrawRay(transform.position, currentDirection, Color.red);
#endif
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
            position.y < (cameraPosition.y - halfHeight))
        {
            return false;
        }
        // Allow up outside camera movement for after finishing.
        if (notesPlay.getCurrentSong() <= 3 && position.y > (cameraPosition.y + halfHeight))
        {
            return false;
        }
        return true;
    }
}
