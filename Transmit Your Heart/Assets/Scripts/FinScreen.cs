using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinScreen : MonoBehaviour {

    public bool startAppear = false;

	// Use this for initialization
	void Start () {
        setObjectAlpha(0f, gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(startAppear == true)
        {
            Color newColor = gameObject.GetComponent<SpriteRenderer>().color;
            newColor.a += 1f * Time.deltaTime;
            setObjectAlpha(0f, gameObject);
        }
	}

    private void setObjectAlpha(float value, GameObject obj)
    {
        Color newColor = obj.GetComponent<SpriteRenderer>().color;
        newColor.a = value;
        obj.GetComponent<SpriteRenderer>().color = newColor;
    }
}
