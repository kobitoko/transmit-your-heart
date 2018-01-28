using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcNotes : MonoBehaviour {
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
    //Song 1 progression: C E G B hC
    public float[] song_1 = {-4.695f, -4.045f, -3.395f, -2.745f, -2.42f};
    public AudioSource[] songs;
    public Transform note;
    public GameObject[] noteClones;
    public int notesPlayed = 0;
    // Use this for initialization
    void Start () {
        songs = GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")) {
            if (!songs[0].isPlaying) {
                songs[0].Play();
                StartCoroutine(DisplayNote(song_1));
                
            }
        }

        if(notesPlayed == 5) {
            DestroyNotes();
        }
	}

    IEnumerator DisplayNote(float[] song) {
        if (notesPlayed < 5) {
            foreach (float item in song) {
                Instantiate(note, new Vector3(-9f + (1.25f * notesPlayed), item, 0), Quaternion.identity);
                yield return new WaitForSeconds(0.75f);
                notesPlayed++;
            }
            noteClones = GameObject.FindGameObjectsWithTag("npcNote");
        }
    }

    void DestroyNotes() {
        for (int i = 0; i < notesPlayed; i++) {
            Destroy(noteClones[i]);
        }
        notesPlayed = 0;
    }
}
