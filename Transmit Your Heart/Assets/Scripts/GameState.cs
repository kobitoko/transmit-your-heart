using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

    public string currentLevel;
    public GameObject musicSliderObject;
    Slider musicSlider;
    public GameObject effectSliderObject;
    Slider effectSlider;

    public float musicVolume;
    public float effectVolume;

	// Use this for initialization
	void Start () {
        musicSlider = musicSliderObject.GetComponent<Slider>();
        effectSlider = effectSliderObject.GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setMusicVolume()
    {
        musicVolume = musicSlider.value;
    }

    public void setEffectVolume()
    {
        effectVolume = effectSlider.value;
    }
}
