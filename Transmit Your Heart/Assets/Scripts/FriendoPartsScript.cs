using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendoPartsScript : InteractableScript
{

    SonarPingScript playerSonar;
    public GameObject uiSlot;

    // Use this for initialization
    new void Start()
    {
        base.Start();
        playerSonar = GameObject.FindGameObjectWithTag("Player").GetComponent<SonarPingScript>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (isNear == true && playerSonar.pingColor != Color.cyan)
        {
            playerSonar.gameObject.GetComponent<SonarPingScript>().changePingColor(Color.cyan);
        }
    }
    public void pickupItem()
    {
        uiSlot.GetComponent<UIInventorySlot>().gatherPart();
        Destroy(gameObject);
    }
}
