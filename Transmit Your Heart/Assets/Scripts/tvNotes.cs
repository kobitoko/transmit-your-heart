﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;


//It's not hard coded
//It's obfuscated
//There's a difference



//THE MAGIC NUMBER IS 4

//Ignore last 5 notes of song_1

public class tvNotes : MonoBehaviour, NotesInterface
{
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

    public List<float> song_1 = new List<float> {3.415f, 3.415f , 3.415f ,2.95f, 2.95f, 2.95f,
        3.165f, 3.165f, 3.165f, 3.415f, 3.415f, 3.415f,3.79f,3.79f,3.79f }; //15
    public List<float> song_2 = new List<float> { 3.29f , 3.29f, 3.415f, 3.415f, 3.52f, 3.52f, 3.665f, 3.665f, 3.79f }; //9
    public List<float> song_3 = new List<float> { 2.95f , 2.95f, 3.04f, 3.04f, 3.165f, 3.165f, 3.29f, 3.165f, 3.04f,
    2.95f,2.95f,3.04f,3.04f,3.165f}; //14


    public AudioSource[] songs;
    public Transform note;
    public GameObject[] noteClones;
    public bool canPlay = false;
    bool song_1Played = false;
    bool song_2Played = false;
    bool song_3Played = false;
    public int notesPlayed = 0;
    public int currentSong = 0;
    public float xOffset = -7.4f;
    public float xScale = 0.9f;
    
    // Use this for initialization
    void Start() {
        songs = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (canPlay == true && Input.GetKeyDown("space")) {
            playSong();
        }
    }

    public bool canPlaySong()
    {
        return canPlay;
    }

    public void setCanPlaySong(bool canIndeed)
    {
        canPlay = canIndeed;
    }

    public int getCurrentSong()
    {
        return currentSong;
    }

    public void setCurrentSong(int newValue)
    {
        currentSong = newValue;
    }

    public void playSong()
    {
        if (!songs[currentSong].isPlaying)
        {
            songs[currentSong].Play();
            if (currentSong == 0)
            {
                DestroyNotes();
                StartCoroutine(DisplaySong1(song_1));
            }
            else if (currentSong == 1)
            {
                DestroyNotes();
                StartCoroutine(DisplaySong2(song_2));
            }
            else if (currentSong == 2)
            {
                DestroyNotes();
                StartCoroutine(DisplaySong3(song_3));
            }
            else if (currentSong == 3)
            {
                PlaySong4();
            }
        }
    }

    IEnumerator DisplaySong1(List<float> song) {
        if (notesPlayed < 15) {
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.55f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.55f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.55f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.55f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.55f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            notesPlayed++;

            //DestroyNotes();
        }
    }

    IEnumerator DisplaySong2(List<float> song) {

        if (notesPlayed < 9) {
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.37f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.37f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.37f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.37f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.37f);
            notesPlayed++;

            //DestroyNotes();
        }
    }

    IEnumerator DisplaySong3(List<float> song) {
        if (notesPlayed < 14) {
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.75f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.75f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.75f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.75f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            notesPlayed++;
            Instantiate(note, new Vector3(xOffset + (xScale * notesPlayed), song[notesPlayed], 0), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            notesPlayed++;

            //DestroyNotes();
        }
    }

    public void PlaySong4() {
    }



    void DestroyNotes() {
        noteClones = GameObject.FindGameObjectsWithTag("npcNote");
        for (int i = 0; i < notesPlayed; i++) {
            Destroy(noteClones[i]);
        }
        notesPlayed = 0;
    }
}
