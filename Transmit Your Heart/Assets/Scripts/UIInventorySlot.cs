using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour {

    //GameObject electronicPart;
    //Sprite sprite;
    bool objectCollected;
    Image image;

    // Use this for initialization
    void Start () {
        objectCollected = false;
        image = GetComponent<Image>();
        Color c = image.color;
        c.a = 0.5f;
        image.color = c;
    }

    public void gatherPart()
    {
        Color c = image.color;
        c.a = 1.0f;
        image.color = c;
        objectCollected = true;
    }
}
