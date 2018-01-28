using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//It's not hard coded
//It's obfuscated
//There's a difference



//THE MAGIC NUMBER IS 4



public class satelliteNotes : MonoBehaviour {
    public List<float> song_1 = new List<float> { -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f };//8
    public List<float> song_2 = new List<float> { -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f };//12
    public List<float> song_3 = new List<float> { -2.395f, -2.395f, -2.395f };//3
    public List<float> song_4 = new List<float> { -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f,
        -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f, -2.395f };
    public AudioSource[] songs;
    public Transform note;
    public GameObject[] noteClones;
    bool song_1Played = false;
    bool song_2Played = false;
    bool song_3Played = false;
    public int notesPlayed = 0;
    public int currentSong = 0;
    public int lastSongNote = 0;
    public float xScale = 1.0f;
    // Use this for initialization
    void Start() {
        songs = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("space")) {
            if (!songs[currentSong].isPlaying) {
                songs[currentSong].Play();
                if (currentSong == 0) {
                    StartCoroutine(DisplaySong1(song_1));
                }
                else if (currentSong == 1) {
                    StartCoroutine(DisplaySong2(song_2));
                }
                else if (currentSong == 2) {
                    StartCoroutine(DisplaySong3(song_3));
                }
                else if (currentSong == 3) {
                    StartCoroutine(DisplaySong4(song_4));
                }
            }
        }
    }

    IEnumerator DisplaySong1(List<float> song) {
        if (notesPlayed < 8) {
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;

            DestroyNotes();
        }
    }

    IEnumerator DisplaySong2(List<float> song) {
        if (notesPlayed < 12) {
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.25f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(2.05f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.9f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(2.05f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;

            DestroyNotes();
        }
    }

    IEnumerator DisplaySong3(List<float> song) {
        if (notesPlayed < 3) {
            yield return new WaitForSeconds(2.4f);
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.9f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.9f);
            notesPlayed++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;

            DestroyNotes();
        }
    }

    IEnumerator DisplaySong4(List<float> song) {
        if (notesPlayed < 23) {
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.75f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.65f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.65f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.9f);
            notesPlayed++;
            lastSongNote++;

            DestroyNotes();
        }

        if (notesPlayed < 23) {
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.25f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(2.05f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.9f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(2.05f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(2.4f);
            notesPlayed++;
            lastSongNote++;

            DestroyNotes();
        }

        if (notesPlayed < 23) {
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.9f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.9f);
            notesPlayed++;
            lastSongNote++;
            Instantiate(note, new Vector3(-9f + (xScale * notesPlayed), song[lastSongNote], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;
            lastSongNote++;

            DestroyNotes();
        }

    }



    void DestroyNotes() {
        noteClones = GameObject.FindGameObjectsWithTag("npcNote");
        for (int i = 0; i < notesPlayed; i++) {
            Destroy(noteClones[i]);
        }
        notesPlayed = 0;
    }
}
