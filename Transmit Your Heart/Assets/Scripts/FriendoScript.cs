using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendoScript : InteractableScript
{

    PlayerScript player;
    SonarPingScript playerSonar;

    // Use this for initialization
    new void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        playerSonar = GameObject.FindGameObjectWithTag("Player").GetComponent<SonarPingScript>();

    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (isNear && player.inventory == 3)
        {
            if (playerSonar.pingColor != Color.green)
            {
                playerSonar.changePingColor(Color.green);
            }
        }
        else if (isNear == true)
        {
            if (playerSonar.pingColor != Color.red)
            {
                playerSonar.changePingColor(Color.red);
            }
        }
    }
}
