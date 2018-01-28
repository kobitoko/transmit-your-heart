using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarWave : MonoBehaviour
{

    public bool playing = false;
    public float biggestSize = 4f;
    public float speed = 1f;

    // Use this for initialization
    void Start()
    {
        setScale(0.1f, gameObject);
        setObjectAlpha(0, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(playing == false)
        {
            setScale(0.1f, gameObject);
            setObjectAlpha(0, gameObject);
        } else if (playing == true) {
            if(gameObject.GetComponent<Transform>().localScale.x < biggestSize)
            {
                setScale(gameObject.GetComponent<Transform>().localScale.x + (speed * Time.deltaTime), gameObject);
                float progress = gameObject.GetComponent<Transform>().localScale.x / biggestSize;
                setObjectAlpha((1-(progress-0.5f)), gameObject);
            } else {
                playing = false;
            }
        }
    }

    private void setObjectAlpha(float value, GameObject obj)
    {
        Color newColor = obj.GetComponent<SpriteRenderer>().color;
        newColor.a = value;
        obj.GetComponent<SpriteRenderer>().color = newColor;
    }

    private void setObjectColor(Color c, GameObject obj)
    {
        Color newColor = obj.GetComponent<SpriteRenderer>().color;
        newColor.r = c.r;
        newColor.g = c.g;
        newColor.b = c.b;
        obj.GetComponent<SpriteRenderer>().color = newColor;
    }

    private void setScale(float value, GameObject obj)
    {
        Vector3 newScale = obj.GetComponent<Transform>().localScale;
        newScale.x = value;
        newScale.y = value;
        obj.GetComponent<Transform>().localScale = newScale;
    }

    public void play()
    {
        setScale(0.1f, gameObject);
        setObjectAlpha(1, gameObject);
        playing = true;
    }

}
