using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuPopupScript : MonoBehaviour {

    public GameObject UIMenuPopup;
	// Use this for initialization
	void Start () {
        UIMenuPopup.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("escape"))
        {
            UIMenuPopup.SetActive(!UIMenuPopup.activeInHierarchy);
        }
    }

    public void shutdownGame()
    {
        Application.Quit();
    }
}
