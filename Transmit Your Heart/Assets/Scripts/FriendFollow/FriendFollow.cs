using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendFollow : MonoBehaviour {

    List<Vector2> footSteps = new List<Vector2>();
    bool isNear = false;

    // Use this for initialization
    void Start () {
        // I am eternal.
        DontDestroyOnLoad(gameObject);
    }
	// Update is called once per frame
	void Update () {
        PlayerScript player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        Vector3 random = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f);
        if (Vector2.Distance(transform.position, player.transform.position) < Random.Range(1f, 3.5f))
        {
            isNear = true;
        } else
        {
            isNear = false;
        }
        if (isNear == true)
        {
            footSteps.Clear();
        }
        if (isNear == false)
        {
            footSteps.Add(player.transform.position + random);
            transform.position = Vector2.LerpUnclamped(transform.position, footSteps[0], (player.walkSpeed * 1.2f) * Time.deltaTime);
        }
        if (footSteps.Count > 0 && Vector2.Distance(footSteps[0], transform.position) < 0.5f)
        {
            footSteps.RemoveAt(0);
        }
        // Visually puts friend infront of player if player is further up in the depth level Y.
        if (player.transform.position.y + player.GetComponent<CircleCollider2D>().offset.y > transform.position.y)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 11;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
        }
    }
}
