using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextPlayer;
using TextPlayer.MML;

public class Board : MonoBehaviour
{
    public GameObject noteBlock;
    public float noteChange = 0.05F;    // amount note moves per fixedUpdate
    internal float noteSpeed;           // noteChange/fixedDeltaTime = how fast notes are moving
    private MMLTest player;

    void Start()
    {
        // find the speed of notes from the amount of units they move every time FixedUpdate is called
        noteSpeed = noteChange / Time.fixedDeltaTime;

        player = new MMLTest();
        player.FromFile("Assets\\Custom\\bigblue.mml");
        player.Play();
    }

    void Update()
    {
        if (player.Playing)
        {
            player.Update();

            System.Threading.Thread.Sleep(1);
        }
    }

    // default speed of 50 times a second or every 0.02 seconds
    private void FixedUpdate()
    {
        UpdateNotes();
    }

    // Create a note based on the type, length, and octave it is
    public void CreateNote(char type, float length, int octave)
    {
        // Find a numerical value for the key type being played
        float position = 0;
        switch (type)
        {
            case 'c':
                position = 0;
                break;
            case 'd':
                position = 1;
                break;
            case 'e':
                position = 2;
                break;
            case 'f':
                position = 3;
                break;
            case 'g':
                position = 4;
                break;
            case 'a':
                position = 5;
                break;
            case 'b':
                position = 6;
                break;
        }

        // Calculate exact position based on octave and space between notes
        position = position + (7 * (octave - 1));
        position = (position * 0.1F) + position;

        // Create vector3 for the location to spawn the note
        Vector3 location = new Vector3(-5, 1, -3.3F);
        location = location + new Vector3(0 - (length / 2), 0, position);

        GameObject newNote = Instantiate(noteBlock, location, Quaternion.identity, gameObject.transform);
        newNote.transform.localScale = new Vector3(length, 1, 1);
    }

    // Update the position for currently spawned notes
    void UpdateNotes()
    {
        foreach (Transform child in transform)
        {
            child.position += new Vector3(noteChange, 0, 0);
        }

    }
}
