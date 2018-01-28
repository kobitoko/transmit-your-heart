using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour {
    public float interactableDistance = 0.75f;
    public KeyItem keyItemPrefab;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        if(Vector2.Distance(transform.position , playerPosition)  < interactableDistance)
        {
            playInteractiveAnim();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().closestFriendPart = gameObject;
        } else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().closestFriendPart == gameObject) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().closestFriendPart = null;
        }
	}
    void playInteractiveAnim()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SonarPingScript>().playPing();
    }

    public KeyItem giveItem()
    {
        GameObject keyItem = Instantiate(keyItemPrefab.gameObject);
        // Hide item.
        //keyItem.GetComponent<SpriteRenderer>()
        return keyItem.GetComponent<KeyItem>();
    }

}
