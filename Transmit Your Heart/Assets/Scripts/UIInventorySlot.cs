using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventorySlot : MonoBehaviour {

    GameObject electronicPart;
    bool objectCollected;

	// Use this for initialization
	void Start () {
        objectCollected = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void gatherPart()
    {
        electronicPart.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        objectCollected = true;
    }

    public void setPart(GameObject _gameObject)
    {
        electronicPart = _gameObject;
        _gameObject.transform.position = gameObject.transform.position;
        _gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }
}
