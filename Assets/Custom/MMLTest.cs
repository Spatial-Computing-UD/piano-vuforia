using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TextPlayer;
using TextPlayer.MML;

public class MMLTest : MMLPlayer
{

    GameObject noteGrid;
    Board board;

    public MMLTest()
        : base() {
        noteGrid = GameObject.FindWithTag("GameController");
        board = noteGrid.GetComponent<Board>();
    }

    // Called everytime a new note needs to be played
    protected override void PlayNote(Note note, int channel, TimeSpan time)
    {
        Debug.Log(note.Type + "" + note.Octave + " " + note.Length);
        // Calculate how long a note should be based on how long it should be played and the note speed
        float length = ( (float)note.Length.TotalSeconds - 0.05F) * board.noteSpeed;
        // Create each note
        board.CreateNote(note.Type, length, note.Octave);
    }

}
