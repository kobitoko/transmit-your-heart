﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarPingScript : MonoBehaviour {

    public GameObject sonarPrefab;
    public int pingCircles = 5;
    public Vector2 offset = Vector2.zero;
    public float pingSize = 4f;
    public float pingSpeed = 1f;
    public Color pingColor = Color.cyan;
    public float betweenWavesTimeSeconds = 0.3f;

    List<GameObject> sonarPings = new List<GameObject>();
    Vector2 pingLocation;
    bool playedOnce = false;

	// Use this for initialization
	void Start () {
        sonarPings.Clear();
        for (int i = 0; i < pingCircles; ++i)
        {
            GameObject toAdd = Instantiate(sonarPrefab);
            toAdd.GetComponent<SonarWave>().biggestSize = pingSize;
            toAdd.GetComponent<SonarWave>().speed = pingSpeed;
            toAdd.GetComponent<SpriteRenderer>().color = pingColor;
            sonarPings.Add(toAdd);
            
        }
	}

    public void playPing()
    {
        if(playedOnce == true) {
            return;
        }
        playedOnce = true;
        StartCoroutine(playPingDelay());
    }

    IEnumerator playPingDelay()
    {
        foreach (GameObject sonar in sonarPings)
        {
            pingLocation = new Vector2(transform.position.x, transform.position.y) + offset;
            sonar.GetComponent<Transform>().position = pingLocation;
            sonar.GetComponent<SonarWave>().play();
            yield return new WaitForSeconds(betweenWavesTimeSeconds);
            
        }
        yield return new WaitWhile(() => sonarPings[sonarPings.Count - 1].GetComponent<SonarWave>().playing);
        playedOnce = false;
    }

}