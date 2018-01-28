using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayNotes : MonoBehaviour {
    
    // lG, lA, lB, C, C#, D, D#, E, F, F#, G, G#, A, A#, B, hC

    public AudioSource[] notes;
    public GameObject[] noteClones;
    public GameObject npc;
    public Transform note;
    public int numNotesPlayed = 0;
    public GameObject UISoundEffectslider;

    public List<string> radio_1Answer = new List<string> { "D", "lG", "lb", "D", "G", "F#", "E", "D"};
    public List<string> radio_2Answer = new List<string> { "E", "D", "C", "D", "lG", "lA" };
    public List<string> radio_3Answer = new List<string> { "E", "F#", "G", "hC", "B", "G"};

    public List<string> tv_1Answer = new List<string> { "D", "D", "D", "lG", "lG", "lG", "lB", "lB", "lB", "D", "D", "D", "G", "G", "G" };
    public List<string> tv_2Answer = new List<string> { "C", "C" ,"D", "D", "E", "E", "F", "F", "G" };
    public List<string> tv_3Answer = new List<string> { "lG", "lG", "lA", "lA", "lB", "lB", "C", "lB", "lA", "lG", "lG", "lA", "lA", "lB" };

    public List<string> satellite_1Answer = new List<string> { "G", "lG", "lB", "D", "G", "F", "E", "D" };
    public List<string> satellite_2Answer = new List<string> { "E", "D", "D", "E", "C","C", "D", "D","E","E","F","F" };
    public List<string> satellite_3Answer = new List<string> { "C", "B", "G" };

    public List<string> playerAnswer = new List<string>();

    public float xOffset = -7.4f;
    public float xScale = 0.9f;

    public float lG = 2.95f;
    public float lA = 3.04f;
    public float lB = 3.165f;
    public float C = 3.29f;
    public float D = 3.415f;
    public float E = 3.52f;
    public float F = 3.665f;
    public float G = 3.79f;
    public float A = 3.915f;
    public float B = 4.04f;
    public float hC = 4.165f;
    // Use this for initialization
    void Start() {
        notes = GetComponents<AudioSource>();
        npc = GameObject.FindGameObjectWithTag("npc");
        
    }

    // Update is called once per frame
    void Update() {
        if(SceneManager.GetActiveScene().name == "Level1") {
            if(npc.GetComponent<tvNotes>().currentSong == 0) {
                TVSong_1Controls();
                if (compareAnswers(playerAnswer, tv_1Answer) == true) {
                    npc.GetComponent<tvNotes>().currentSong++;
                    DestroyInstant();
                }
            }
            else if(npc.GetComponent<tvNotes>().currentSong == 1) {
                TVSong_2Controls();
                if (compareAnswers(playerAnswer, tv_2Answer) == true) {
                    npc.GetComponent<tvNotes>().currentSong++;
                    DestroyInstant();
                }
            }
            else if(npc.GetComponent<tvNotes>().currentSong == 2) {
                TVSong_3Controls();
                if (compareAnswers(playerAnswer, tv_3Answer) == true) {
                    npc.GetComponent<tvNotes>().currentSong++;
                    DestroyInstant();
                }
            }
        }else if(SceneManager.GetActiveScene().name == "Level2") {
            if (npc.GetComponent<radioNotes>().currentSong == 0) {
                RadioSong_1Controls();
                if (compareAnswers(playerAnswer, radio_1Answer) == true) {
                    npc.GetComponent<radioNotes>().currentSong++;
                    DestroyInstant();
                }

            }
            else if (npc.GetComponent<radioNotes>().currentSong == 1) {
                RadioSong_2Controls();
                if (compareAnswers(playerAnswer, radio_2Answer) == true) {
                    npc.GetComponent<radioNotes>().currentSong++;
                    DestroyInstant();
                }
            }
            else if (npc.GetComponent<radioNotes>().currentSong == 2) {
                RadioSong_3Controls();
                if (compareAnswers(playerAnswer, radio_3Answer) == true) {
                    npc.GetComponent<radioNotes>().currentSong++;
                    DestroyInstant();
                }
            }
        }
        else if(SceneManager.GetActiveScene().name == "Level3") {
            if (npc.GetComponent<satelliteNotes>().currentSong == 0) {
                SatelliteSong_1Controls();
                if (compareAnswers(playerAnswer, satellite_1Answer) == true) {
                    npc.GetComponent<satelliteNotes>().currentSong++;
                    DestroyInstant();
                }
            }
            else if (npc.GetComponent<satelliteNotes>().currentSong == 1) {
                SatelliteSong_2Controls();
                if (compareAnswers(playerAnswer, satellite_2Answer) == true) {
                    npc.GetComponent<satelliteNotes>().currentSong++;
                    DestroyInstant();
                }
            }
            else if (npc.GetComponent<satelliteNotes>().currentSong == 2) {
                SatelliteSong_3Controls();
                if (compareAnswers(playerAnswer, satellite_2Answer) == true) {
                    npc.GetComponent<satelliteNotes>().currentSong++;
                    DestroyInstant();
                }
            }
        }
    }
    
    void DisplayNote(Vector3 position) {
        if (numNotesPlayed < 15) {
            Instantiate(note, position, Quaternion.identity);
            if (numNotesPlayed == 0) {
                StartCoroutine(DestroyNotes());
            }
            noteClones = GameObject.FindGameObjectsWithTag("Note");
            numNotesPlayed++;
        }
    }

    IEnumerator WaitForSong() {
        yield return new WaitForSeconds(3);
    }
    IEnumerator DestroyNotes() {
        yield return new WaitForSeconds(10);
        for (int i = 0; i < numNotesPlayed; i++) {
            Destroy(noteClones[i]);
        }
        playerAnswer.Clear();
        numNotesPlayed = 0;
    }
    void DestroyInstant() {
        for (int i = 0; i < numNotesPlayed; i++) {
            Destroy(noteClones[i]);
        }
        playerAnswer.Clear();
        numNotesPlayed = 0;
    }

    public bool compareAnswers(List<string> list1, List<string> list2) {
        if(list1.Count != list2.Count) {
            return false;
        }
    
        for (int i = 0; i < list1.Count; i++) {
            Debug.Log(list1[i]);
            Debug.Log(list2[i]);
            if (list1[i] != list2[i]) {
                Debug.Log("false");
                return false;
            }
        }
        return true;
    }



    void RadioSong_1Controls() {

        //D
        if (Input.GetKeyDown("1")) {
            playerAnswer.Add("D");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), D, 0));
            notes[5].Play();
            
        }
        //lG
        if (Input.GetKeyDown("2")) {
            playerAnswer.Add("lG");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), lG, 0));
            notes[0].Play();
        }
        //lB
        if (Input.GetKeyDown("3")) {
            playerAnswer.Add("lB");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), lB, 0));
            notes[3].Play();
        }
        //G
        if (Input.GetKeyDown("8")) {
            playerAnswer.Add("G");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), G, 0));
            notes[10].Play();
        }
        //F#
        if (Input.GetKeyDown("9")) {
            playerAnswer.Add("F#");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), F, 0));
            notes[9].Play();
        }
        //E
        if (Input.GetKeyDown("0")) {
            playerAnswer.Add("E");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), E, 0));
            notes[7].Play();
        }
    }

    void RadioSong_2Controls() {
        //E
        if (Input.GetKeyDown("1")) {
            playerAnswer.Add("E");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), E, 0));
            notes[7].Play();
        }
        //D
        if (Input.GetKeyDown("2")) {
            playerAnswer.Add("D");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), D, 0));
            notes[5].Play();
        }
        //C
        if (Input.GetKeyDown("3")) {
            playerAnswer.Add("C");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), C, 0));
            notes[3].Play();
        }
        //lG
        if (Input.GetKeyDown("8")) {
            playerAnswer.Add("lG");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), lG, 0));
            notes[0].Play();
        }
        //lA
        if (Input.GetKeyDown("9")) {
            playerAnswer.Add("lA");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), lA, 0));
            notes[1].Play();
        }

    }
    void RadioSong_3Controls() {
        //E
        if (Input.GetKeyDown("1")) {
            playerAnswer.Add("E");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), E, 0));
            notes[7].Play();
        }
        //F#
        if (Input.GetKeyDown("2")) {
            playerAnswer.Add("F#");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), F, 0));
            notes[9].Play();
        }
        //G
        if (Input.GetKeyDown("3")) {
            playerAnswer.Add("G");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), G, 0));
            notes[10].Play();
        }
        //hC
        if (Input.GetKeyDown("8")) {
            playerAnswer.Add("hC");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), hC, 0));
            notes[15].Play();
        }
        //B
        if (Input.GetKeyDown("9")) {
            playerAnswer.Add("B");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), B, 0));
            notes[14].Play();
        }

    }

    void TVSong_1Controls() {
        //D
        if (Input.GetKeyDown("1")) {
            playerAnswer.Add("D");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), D, 0));
            notes[5].Play();
        }
        //lG
        if (Input.GetKeyDown("2")) {
            playerAnswer.Add("lG");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), lG, 0));
            notes[0].Play();
        }
        //lB
        if (Input.GetKeyDown("3")) {
            playerAnswer.Add("lB");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), lB, 0));
            notes[2].Play();

        }
        //G
        if (Input.GetKeyDown("8")) {
            playerAnswer.Add("G");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), G, 0));
            notes[10].Play();
        }

    }
    void TVSong_2Controls() {
        //C
        if (Input.GetKeyDown("1")) {
            playerAnswer.Add("C");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), C, 0));
            notes[3].Play();
        }
        //D
        if (Input.GetKeyDown("2")) {
            playerAnswer.Add("D");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), D, 0));
            notes[5].Play();
        }
        //E
        if (Input.GetKeyDown("3")) {
            playerAnswer.Add("E");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), E, 0));
            notes[7].Play();
        }
        //F
        if (Input.GetKeyDown("8")) {
            playerAnswer.Add("F");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), F, 0));
            notes[8].Play();
        }
        //G
        if (Input.GetKeyDown("9")) {
            playerAnswer.Add("G");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), G, 0));
            notes[10].Play();
        }

    }
    void TVSong_3Controls() {
        //lG
        if (Input.GetKeyDown("1")) {
            playerAnswer.Add("lG");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), lG, 0));
            notes[0].Play();
        }
        //lA
        if (Input.GetKeyDown("2")) {
            playerAnswer.Add("lA");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), lA, 0));
            notes[1].Play();
        }
        //lB
        if (Input.GetKeyDown("3")) {
            playerAnswer.Add("lB");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), lB, 0));
            notes[2].Play();
        }
        //C
        if (Input.GetKeyDown("8")) {
            playerAnswer.Add("C");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), C, 0));
            notes[3].Play();
        }
    }
    void SatelliteSong_1Controls() {
        //G
        if (Input.GetKeyDown("1")) {
            playerAnswer.Add("G");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), G, 0));
            notes[10].Play();
        }
        //lG
        if (Input.GetKeyDown("2")) {
            playerAnswer.Add("lG");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), lG, 0));
            notes[0].Play();
        }
        //lB
        if (Input.GetKeyDown("3")) {
            playerAnswer.Add("lB");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), lB, 0));
            notes[2].Play();
        }
        //D
        if (Input.GetKeyDown("8")) {
            playerAnswer.Add("D");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), D, 0));
            notes[5].Play();
        }
        //E
        if (Input.GetKeyDown("9")) {
            playerAnswer.Add("E");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), E, 0));
            notes[7].Play();
        }
        //F
        if (Input.GetKeyDown("0")) {
            playerAnswer.Add("F");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), F, 0));
            notes[8].Play();
        }

    }
    void SatelliteSong_2Controls() {
        //E
        if (Input.GetKeyDown("1")) {
            playerAnswer.Add("E");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), E, 0));
            notes[7].Play();
        }
        //D
        if (Input.GetKeyDown("2")) {
            playerAnswer.Add("D");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), D, 0));
            notes[5].Play();
        }
        //C
        if (Input.GetKeyDown("3")) {
            playerAnswer.Add("C");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), C, 0));
            notes[3].Play();
        }
        //F
        if (Input.GetKeyDown("8")) {
            playerAnswer.Add("F");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), F, 0));
            notes[8].Play();
        }

    }
    void SatelliteSong_3Controls() {
        //C
        if (Input.GetKeyDown("1")) {
            playerAnswer.Add("C");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), C, 0));
            notes[15].Play();
        }
        //B
        if (Input.GetKeyDown("2")) {
            playerAnswer.Add("B");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), B, 0));
            notes[14].Play();
        }
        //G
        if (Input.GetKeyDown("3")) {
            playerAnswer.Add("G");
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), G, 0));
            notes[0].Play();
        }
    }

    public void setVolume()
    {
        Slider soundEffectSlider = UISoundEffectslider.GetComponent<Slider>();
        foreach(AudioSource audio in notes)
        {
            audio.volume = 1.0f * (soundEffectSlider.value / 100.0f);
        }
    }
}
