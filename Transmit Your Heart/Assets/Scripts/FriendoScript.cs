using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendoScript : InteractableScript
{

    public Sprite fixedSprite;

    PlayerScript player;
    SonarPingScript playerSonar;
    bool nowFixed = false;

    List<Vector2> footSteps = new List<Vector2>();

    // Use this for initialization
    new void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        playerSonar = GameObject.FindGameObjectWithTag("Player").GetComponent<SonarPingScript>();

    }

    public void gotFixed()
    {
        nowFixed = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = fixedSprite;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (isNear == true)
        {
            if (playerSonar.pingColor != Color.green && player.inventory >= 3)
            {
                playerSonar.changePingColor(Color.green);
            }
            else if (player.inventory < 3 && playerSonar.pingColor != Color.red)
            {
                playerSonar.changePingColor(Color.red);
            }
            footSteps.Clear();
        }
        if (isNear == false && nowFixed == true)
        {
            footSteps.Add(player.transform.position);
            transform.position = Vector2.LerpUnclamped(transform.position, footSteps[0], (player.walkSpeed * 1.5f) * Time.deltaTime);
        }
        if (footSteps.Count > 0 && Vector2.Distance(footSteps[0], transform.position) < 0.5f)
        {
            footSteps.RemoveAt(0);
        }
    }

}
