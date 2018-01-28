using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNotes : MonoBehaviour {
    
    //Start X positions at -9 and increment by 1.25 every note. 

    public AudioSource[] notes;
    public GameObject[] noteClones;
    public GameObject npc;
    public Transform note;
    public Transform noteSharp;
    public int numNotesPlayed = 0;
    public List<float> notesPlayed = new List<float>();
    public bool rightSong = false;
    // Use this for initialization
    void Start() {
        notes = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }

    void DisplayNote(Vector3 position) {
        if (numNotesPlayed < 15) {
            Instantiate(note, position, Quaternion.identity);
            notesPlayed.Add(position.y);
            if (compareSongs(notesPlayed,npc.GetComponent<radioNotes>().song_1) == true) {
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
        yield return new WaitForSeconds(7);
        for (int i = 0; i < numNotesPlayed; i++) {
            Destroy(noteClones[i]);
        }
        Debug.Log(rightSong);
        notesPlayed.Clear();
        numNotesPlayed = 0;
    }

    public bool compareSongs(List<float> list1, List<float> list2) {
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
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //G
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //B
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //F#
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //E
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
    }

    void RadioSong_2Controls() {
        //E
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //D
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //C
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //G
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //A
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }

    }
    void RadioSong_3Controls() {
        //E
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //F#
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //G
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //C
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //B
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }

    }

    void TVSong_1Controls() {
        //D
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //G
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //B
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }

    }
    void TVSong_2Controls() {
        //C
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //D
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //E
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //F
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //G
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }

    }
    void TVSong_3Controls() {
        //G
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //A
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //B
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //C
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
    }
    void SatelliteSong_1Controls() {
        //hG
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //lG
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //B
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //D
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //E
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //F
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }

    }
    void SatelliteSong_2Controls() {
        //E
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //D
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //lC
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //F
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }

    }
    void SatelliteSong_3Controls() {
        //hC
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //B
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        //lG
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
    }
}
