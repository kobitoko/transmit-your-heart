﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    public string currentLevel;
    public GameObject musicSliderObject;
    Slider musicSlider;
    public GameObject effectSliderObject;
    Slider effectSlider;
    public float musicVolume;
    public float effectVolume;

    GameObject fadeObject;
    bool doFadeOut = false;
    bool fadeIn = true;
    public float fadeSpeed = 2f;


    // Use this for initialization
    void Start()
    {
        musicSlider = musicSliderObject.GetComponent<Slider>();
        effectSlider = effectSliderObject.GetComponent<Slider>();
        fadeObject = GameObject.Find("blackFade");
    }

    // Update is called once per frame
    void Update()
    {
        if (doFadeOut == true)
        {
            float alphaValue = fadeObject.GetComponent<SpriteRenderer>().color.a;
            setObjectAlpha(alphaValue + (fadeSpeed * Time.deltaTime), fadeObject);
            if(fadeObject.GetComponent<SpriteRenderer>().color.a < 0.9)
            {
                // Load next scene/level
                Debug.Log("Done!");
                if(SceneManager.GetActiveScene().name == "Level1")
                {
                    SceneManager.LoadScene("Level2");
                } else if(SceneManager.GetActiveScene().name == "Level2") {
                    SceneManager.LoadScene("Level3");
                } else if (SceneManager.GetActiveScene().name == "Level3") {
                    // Thanks for playing
                }
            }
        }
        if (fadeIn == true)
        {
            float alphaValue = fadeObject.GetComponent<SpriteRenderer>().color.a;
            setObjectAlpha(alphaValue - (fadeSpeed * Time.deltaTime), fadeObject);
            if (fadeObject.GetComponent<SpriteRenderer>().color.a < 0.1)
            {
                fadeObject.SetActive(false);
                fadeIn = false;
            }
        }
    }

    public void setMusicVolume()
    {
        musicVolume = musicSlider.value;
    }

    public void setEffectVolume()
    {
        effectVolume = effectSlider.value;
    }

    private void setObjectAlpha(float value, GameObject obj)
    {
        Color newColor = obj.GetComponent<SpriteRenderer>().color;
        newColor.a = value;
        obj.GetComponent<SpriteRenderer>().color = newColor;
    }

    public void fadeOut()
    {
        fadeObject.SetActive(true);
        doFadeOut = true;
    }

}
