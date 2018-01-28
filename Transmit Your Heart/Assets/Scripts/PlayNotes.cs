using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNotes : MonoBehaviour {

    //Y Positions for staff:
    //C = -4.67
    //D = -4.345
    //E = -4.02
    //F = -3.695
    //G = -3.37
    //A = -2.72
    //B = -3.395
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
        
        if (Input.GetKeyDown("a")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), -4.67f, 0));
            notes[0].Play();
        }
        if (Input.GetKeyDown("s")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), -4.345f, 0));
            notes[1].Play();

        }
        if (Input.GetKeyDown("d")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), -4.02f, 0));
            notes[2].Play();
        }
        if (Input.GetKeyDown("f")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), -3.695f, 0));
            notes[3].Play();
        }
        if (Input.GetKeyDown("g")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), -3.37f, 0));
            notes[4].Play();
        }
        if (Input.GetKeyDown("h")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), -3.045f, 0));
            notes[5].Play();
        }
        if (Input.GetKeyDown("j")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), -2.72f, 0));
            notes[6].Play();
        }
        if (Input.GetKeyDown("k")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), -2.395f, 0));
            notes[7].Play();
        }
        if (Input.GetKeyDown("l")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), -1.12f, 0));
            notes[8].Play();
        }
        if (Input.GetKeyDown("z")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), -0.795f, 0));
            notes[9].Play();
        }
        if (Input.GetKeyDown("x")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), -0.47f, 0));
            notes[10].Play();
        }
        if (Input.GetKeyDown("c")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), -0.145f, 0));
            notes[11].Play();
        }
        if (Input.GetKeyDown("v")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.18f, 0));
            notes[12].Play();
        }
        if (Input.GetKeyDown("b")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.505f, 0));
            notes[13].Play();
        }
        if (Input.GetKeyDown("n")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 0.83f, 0));
            notes[14].Play();
        }
        if (Input.GetKeyDown("m")) {
            DisplayNote(new Vector3(-9f + (1.25f * numNotesPlayed), 1.155f, 0));
            notes[15].Play();
        }


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

    
}
