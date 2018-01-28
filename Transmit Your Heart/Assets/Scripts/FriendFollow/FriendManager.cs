using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour {
    
    public List<FriendFollow> friends = new List<FriendFollow>();

	// Use this for initialization
	void Start () {
        // I am eternal.
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
