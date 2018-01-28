using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour {
    public float interactableDistance = 0.75f;
    Vector3 defaultScale;

	// Use this for initialization
	void Start () {
        defaultScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        if(Vector2.Distance(transform.position , playerPosition)  < interactableDistance)
        {
            playInteractiveAnim();
        }
	}
    void playInteractiveAnim()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SonarPingScript>().playPing();
    }
}
