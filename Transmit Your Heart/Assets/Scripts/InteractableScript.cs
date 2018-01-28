using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour {
    public float interactableDistance = 1f;

	// Use this for initialization
	protected void Start () {
	}
	
	// Update is called once per frame
	protected void Update () {
        Vector2 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        if(Vector2.Distance(transform.position , playerPosition)  < interactableDistance)
        {
            playInteractiveAnim();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().closestFriendPart = gameObject;
        } else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().closestFriendPart == gameObject) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().closestFriendPart = null;
        }
	}
    protected void playInteractiveAnim()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SonarPingScript>().playPing();
    }

}
