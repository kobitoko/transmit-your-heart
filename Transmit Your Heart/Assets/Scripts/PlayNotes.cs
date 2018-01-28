using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayNotes : MonoBehaviour {
    
    //Start X positions at -9 and increment by 1.25 every note. 
    // lG, lA, lB, C, C#, D, D#, E, F, F#, G, G#, A, A#, B, hC
    public AudioSource[] notes;
    public GameObject[] noteClones;
    public GameObject npc;
    public Transform note;
    public int numNotesPlayed = 0;
    public List<float> notesPlayed = new List<float>();
    public bool rightSong = false;

    public List<string> radio_1Answer = new List<string> { "D", "G", "B", "D", "G", "F#", "E", "D" };
    public List<string> radio_2Answer = new List<string> { "E", "D", "C", "D", "G", "A" };
    public List<string> radio_3Answer = new List<string> { "E", "F#", "G", "C", "B", "G"};
    public List<string> radio_4Answer = new List<string> { "D", "G", "B", "D", "G", "F#", "E", "D", "E", "D", "C", "D", "G", "A", "E", "F#", "G", "C", "B", "G" };

    public List<string> tv_1Answer = new List<string> { "D", "G", "B", "D", "G" };
    public List<string> tv_2Answer = new List<string> { "C", "D", "E", "F", "G" };
    public List<string> tv_3Answer = new List<string> { "G", "A", "B", "A", "G", "A", "G" };
    public List<string> tv_4Answer = new List<string> { "D", "G", "B", "D", "G", "C", "D", "E", "F", "G", "G", "A", "B", "A", "G", "A", "G" };

    public List<string> satellite_1Answer = new List<string> { "G", "lG", "B", "D", "G", "F", "E", "D" };
    public List<string> satellite_2Answer = new List<string> { "E", "D", "C", "D", "E","F" };
    public List<string> satellite_3Answer = new List<string> { "hC", "B", "lG" };
    public List<string> satellite_4Answer = new List<string> { "G", "lG", "B", "D", "G", "F", "E", "D", "E", "D", "C", "D", "E", "F", "hC", "B", "lG" };

    public List<string> playerAnswer = new List<string>();

    public float xOffset = -5.0f;
    public float xScale = 1.0f;
    // Use this for initialization
    void Start() {
        notes = GetComponents<AudioSource>();
        npc = GameObject.FindGameObjectWithTag("npc");
        
    }

    // Update is called once per frame
    void Update() {
        if(SceneManager.GetActiveScene().name == "Level1") {
            if(npc.GetComponent<radioNotes>().currentSong == 0) {
                RadioSong_1Controls();
            }
        }else if(SceneManager.GetActiveScene().name == "Level2") {
            TVSong_1Controls();
        }else if(SceneManager.GetActiveScene().name == "Level3") {
            SatelliteSong_1Controls();
        }
    }

    void DisplayNote(Vector3 position, List<string> currentAnswer) {
        if (numNotesPlayed < 15) {
            Instantiate(note, position, Quaternion.identity);
            notesPlayed.Add(position.y);
            if (compareSongs(playerAnswer, currentAnswer) == true) {
                Debug.Log("TRUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
            }
            if (numNotesPlayed == 0) {
                StartCoroutine(DestroyNotes());
            }
            noteClones = GameObject.FindGameObjectsWithTag("Note");
            numNotesPlayed++;
        }
    }

    IEnumerator DestroyNotes() {
        yield return new WaitForSeconds(10);
        for (int i = 0; i < numNotesPlayed; i++) {
            Destroy(noteClones[i]);
        }
        Debug.Log(rightSong);
        notesPlayed.Clear();
        numNotesPlayed = 0;
    }

    public bool compareSongs(List<string> list1, List<string> list2) {
        if(list1.Count != list2.Count) {
            return false;
        }

        for(int i = 0; i < list1.Count; i++)
            if(list1[i] != list2[i]) {
                return false;
            }
        return true;
    }



    void RadioSong_1Controls() {

        //D
        if (Input.GetKeyDown("1")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_1Answer);
            playerAnswer.Add("D");
            notes[5].Play();
        }
        //G
        if (Input.GetKeyDown("2")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_1Answer);
            playerAnswer.Add("G");
            notes[10].Play();
        }
        //B
        if (Input.GetKeyDown("3")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_1Answer);
            playerAnswer.Add("B");
            notes[14].Play();
        }
        //F#
        if (Input.GetKeyDown("8")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_1Answer);
            playerAnswer.Add("F#");
            notes[9].Play();
        }
        //E
        if (Input.GetKeyDown("9")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_1Answer);
            playerAnswer.Add("E");
            notes[7].Play();
        }
    }

    void RadioSong_2Controls() {
        //E
        if (Input.GetKeyDown("1")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_2Answer);
            playerAnswer.Add("E");
            notes[7].Play();
        }
        //D
        if (Input.GetKeyDown("2")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_2Answer);
            playerAnswer.Add("D");
            notes[5].Play();
        }
        //C
        if (Input.GetKeyDown("3")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_2Answer);
            playerAnswer.Add("C");
            notes[3].Play();
        }
        //G
        if (Input.GetKeyDown("8")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_2Answer);
            playerAnswer.Add("G");
            notes[10].Play();
        }
        //A
        if (Input.GetKeyDown("9")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_2Answer);
            playerAnswer.Add("A");
            notes[12].Play();
        }

    }
    void RadioSong_3Controls() {
        //E
        if (Input.GetKeyDown("1")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_3Answer);
            playerAnswer.Add("E");
            notes[7].Play();
        }
        //F#
        if (Input.GetKeyDown("2")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_3Answer);
            playerAnswer.Add("F#");
            notes[9].Play();
        }
        //G
        if (Input.GetKeyDown("3")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_3Answer);
            playerAnswer.Add("G");
            notes[10].Play();
        }
        //C
        if (Input.GetKeyDown("8")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_3Answer);
            playerAnswer.Add("C");
            notes[3].Play();
        }
        //B
        if (Input.GetKeyDown("9")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), radio_3Answer);
            playerAnswer.Add("B");
            notes[14].Play();
        }

    }

    void TVSong_1Controls() {
        //D
        if (Input.GetKeyDown("1")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), tv_1Answer);
            playerAnswer.Add("D");
            notes[5].Play();
        }
        //G
        if (Input.GetKeyDown("2")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), tv_1Answer);
            playerAnswer.Add("G");
            notes[10].Play();
        }
        //B
        if (Input.GetKeyDown("3")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), tv_1Answer);
            playerAnswer.Add("B");
            notes[14].Play();
        }

    }
    void TVSong_2Controls() {
        //C
        if (Input.GetKeyDown("1")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), tv_2Answer);
            playerAnswer.Add("C");
            notes[3].Play();
        }
        //D
        if (Input.GetKeyDown("2")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), tv_2Answer);
            playerAnswer.Add("D");
            notes[14].Play();
        }
        //E
        if (Input.GetKeyDown("3")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), tv_2Answer);
            playerAnswer.Add("E");
            notes[7].Play();
        }
        //F
        if (Input.GetKeyDown("8")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), tv_2Answer);
            playerAnswer.Add("F");
            notes[8].Play();
        }
        //G
        if (Input.GetKeyDown("9")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), tv_2Answer);
            playerAnswer.Add("G");
            notes[10].Play();
        }

    }
    void TVSong_3Controls() {
        //G
        if (Input.GetKeyDown("1")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), tv_3Answer);
            playerAnswer.Add("G");
            notes[10].Play();
        }
        //A
        if (Input.GetKeyDown("2")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), tv_3Answer);
            playerAnswer.Add("A");
            notes[12].Play();
        }
        //B
        if (Input.GetKeyDown("3")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), tv_3Answer);
            playerAnswer.Add("B");
            notes[14].Play();
        }
        //C
        if (Input.GetKeyDown("8")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), tv_3Answer);
            playerAnswer.Add("C");
            notes[3].Play();
        }
    }
    void SatelliteSong_1Controls() {
        //G
        if (Input.GetKeyDown("1")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), satellite_1Answer);
            playerAnswer.Add("G");
            notes[10].Play();
        }
        //lG
        if (Input.GetKeyDown("2")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), satellite_1Answer);
            playerAnswer.Add("lG");
            notes[0].Play();
        }
        //B
        if (Input.GetKeyDown("3")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), satellite_1Answer);
            playerAnswer.Add("B");
            notes[14].Play();
        }
        //D
        if (Input.GetKeyDown("8")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), satellite_1Answer);
            playerAnswer.Add("D");
            notes[5].Play();
        }
        //E
        if (Input.GetKeyDown("9")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), satellite_1Answer);
            playerAnswer.Add("E");
            notes[7].Play();
        }
        //F
        if (Input.GetKeyDown("0")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), satellite_1Answer);
            playerAnswer.Add("F");
            notes[8].Play();
        }

    }
    void SatelliteSong_2Controls() {
        //E
        if (Input.GetKeyDown("1")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), satellite_2Answer);
            playerAnswer.Add("E");
            notes[7].Play();
        }
        //D
        if (Input.GetKeyDown("2")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), satellite_2Answer);
            playerAnswer.Add("D");
            notes[5].Play();
        }
        //C
        if (Input.GetKeyDown("3")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), satellite_2Answer);
            playerAnswer.Add("C");
            notes[3].Play();
        }
        //F
        if (Input.GetKeyDown("8")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), satellite_2Answer);
            playerAnswer.Add("F");
            notes[8].Play();
        }

    }
    void SatelliteSong_3Controls() {
        //hC
        if (Input.GetKeyDown("1")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), satellite_3Answer);
            playerAnswer.Add("hC");
            notes[15].Play();
        }
        //B
        if (Input.GetKeyDown("2")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), satellite_3Answer);
            playerAnswer.Add("B");
            notes[14].Play();
        }
        //lG
        if (Input.GetKeyDown("3")) {
            DisplayNote(new Vector3(xOffset + (xScale * numNotesPlayed), 0.83f, 0), satellite_3Answer);
            playerAnswer.Add("lG");
            notes[0].Play();
        }
    }
}
