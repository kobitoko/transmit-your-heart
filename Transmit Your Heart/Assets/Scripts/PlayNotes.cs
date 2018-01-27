using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNotes : MonoBehaviour {

    //Y Positions for staff:
    //c = -4.695
    //D = -4.37
    //E = -4.045
    //F = -3.72
    //G = -3.395
    //A = -3.07
    //B = -2.745
    //hC = -2.42
    //hD = -2.095
    //hE = -1.77
    //hF = -1.445
    //hG
    //hA
    //hB
    //Start X positions at -9 and increment by 1.25 every note. 

    public AudioSource[] notes;
    public GameObject[] noteClones;
    public Transform note;
    public int notesPlayed = 0;
	// Use this for initialization
	void Start () {
        notes = GetComponents<AudioSource>();
        InvokeRepeating("DestroyNotes", 0.0f, 5.0f);
    }
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetKeyDown("s")) {
            DisplayNote(new Vector3(-9f + (1.25f * notesPlayed), -4.695f, 0));
            notes[0].Play();
        }
        if (Input.GetKeyUp("s")) {
        }

        if (Input.GetKeyDown("d")) {
            DisplayNote(new Vector3(-9f + (1.25f * notesPlayed), -4.045f, 0));
            notes[1].Play();
            
        }
        if (Input.GetKeyUp("d")) {
        }

        if (Input.GetKeyDown("f")) {
            DisplayNote(new Vector3(-9f + (1.25f * notesPlayed), -3.395f, 0));
            notes[2].Play();
        }
        if (Input.GetKeyUp("f")) {
        }

        if (Input.GetKeyDown("g")) {
            DisplayNote(new Vector3(-9f + (1.25f * notesPlayed), -2.745f, 0));
            notes[3].Play();
        }
        if (Input.GetKeyUp("g")) {
        }

        if (Input.GetKeyDown("h")) {
            DisplayNote(new Vector3(-9f + (1.25f * notesPlayed), -2.42f, 0));
            notes[4].Play();
        }
        if (Input.GetKeyUp("h")) {
        }
       

    }

    void DisplayNote(Vector3 position) {
        if (notesPlayed < 15) {
            Instantiate(note, position, Quaternion.identity);
            noteClones = GameObject.FindGameObjectsWithTag("Note");
            notesPlayed++;
        }
    }

    void DestroyNotes() {
        for(int i = 0; i < notesPlayed; i++) {
            Destroy(noteClones[i]);
        }
        notesPlayed = 0;
    }
}
