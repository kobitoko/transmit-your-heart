using System.Collections;
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

    public GameObject friendo;


    // Use this for initialization
    void Start()
    {
        musicSlider = musicSliderObject.GetComponent<Slider>();
        effectSlider = effectSliderObject.GetComponent<Slider>();
        fadeObject = GameObject.Find("blackFade");
        if(SceneManager.GetActiveScene().name == "Level4")
        {
            GameObject friendManager = GameObject.Find("FriendManager");
            foreach(FriendFollow friendBye in friendManager.GetComponent<FriendManager>().friends)
            {
                Destroy(friendBye);
            }
            Destroy(friendManager);
            GameObject.Find("Part Slots").SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (doFadeOut == true)
        {
            float alphaValue = fadeObject.GetComponent<SpriteRenderer>().color.a;
            setObjectAlpha(alphaValue + (fadeSpeed * Time.deltaTime), fadeObject);
            if (fadeObject.GetComponent<SpriteRenderer>().color.a >= 0.98)
            {
                // Add a fake friend, the real friend is destroyed in this scene (T-T)
                GameObject friendManager = GameObject.Find("FriendManager");
                float cameraHeight = Camera.main.GetComponent<Camera>().orthographicSize;
                Vector3 newHeight = new Vector3(0f, -1 * (cameraHeight + 1), 0f);
                // Every cloned friend line up behind the screen.
                if (friendManager.GetComponent<FriendManager>().friends.Count > 0)
                {
                    foreach (FriendFollow clone in friendManager.GetComponent<FriendManager>().friends)
                    {
                        clone.GetComponent<Transform>().position = newHeight;
                    }
                }
                // Add a new cloned friend.
                GameObject clonedFriend = Instantiate(friendo, newHeight, Quaternion.identity);
                GameObject friendToClone = GameObject.FindGameObjectWithTag("npc");
                Sprite realFriendLooks = friendToClone.GetComponentInParent<SpriteRenderer>().sprite;
                clonedFriend.GetComponent<SpriteRenderer>().sprite = realFriendLooks;
                friendManager.GetComponent<FriendManager>().friends.Add(clonedFriend.GetComponent<FriendFollow>());

                // Load next scene/level
                Debug.Log("Done!");
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    SceneManager.LoadScene("Level2");
                }
                else if (SceneManager.GetActiveScene().name == "Level2")
                {
                    SceneManager.LoadScene("Level3");
                }
                else if (SceneManager.GetActiveScene().name == "Level3")
                {
                    // Thanks for playing
                    SceneManager.LoadScene("Level4");
                }
            }
        }
        if (fadeIn == true)
        {
            float alphaValue = fadeObject.GetComponent<SpriteRenderer>().color.a;
            setObjectAlpha(alphaValue - (fadeSpeed * Time.deltaTime), fadeObject);
            if (fadeObject.GetComponent<SpriteRenderer>().color.a <= 0.02)
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
