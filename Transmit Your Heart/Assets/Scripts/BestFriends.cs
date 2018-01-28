using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestFriends : MonoBehaviour {

    public List<Vector2> pathToWalk = new List<Vector2>(5);
    bool readyGo = false;

    // Use this for initialization
    void Start () {
        StartCoroutine(findBestFriend());
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<SonarPingScript>().playPing();
        if (pathToWalk.Count > 0 && readyGo == true)
        {
            gameObject.GetComponent<Transform>().position = Vector2.MoveTowards(transform.position, pathToWalk[0], 2f * Time.deltaTime);
            if (Vector2.Distance(transform.position, pathToWalk[0]) < 0.3f && pathToWalk.Count > 0)
            {
                pathToWalk.RemoveAt(0);
                gameObject.GetComponent<SonarPingScript>().changePingColor(Random.ColorHSV(0f, 1f, 0.8f, 1f, 0.6f, 1f));
                gameObject.GetComponent<SonarPingScript>().changePingSpeed(Random.Range(0.8f, 1.5f));
                gameObject.GetComponent<SonarPingScript>().changePingSize(Random.Range(0.8f, 1.3f));
            }
        }
        // Visually puts friend infront of player if player is further up in the depth level Y.
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.y + player.GetComponent<CircleCollider2D>().offset.y > transform.position.y)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 11;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
        }
    }

    IEnumerator findBestFriend()
    {
        yield return new WaitForSeconds(15);
        readyGo = true;
    }

}
