using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TextPlayer;
using TextPlayer.MML;

public class MMLBehavior : MMLPlayer
{

    GameObject noteGrid;
    Grid grid;

    public MMLBehavior()
        : base() {
        noteGrid = GameObject.FindWithTag("GameController");
        grid = noteGrid.GetComponent<Grid>();
    }

    // Called everytime a new note needs to be played
    protected override void PlayNote(Note note, int channel, TimeSpan time)
    {
        Debug.Log(note.Type + "" + note.Octave + " " + note.Length);
        // Calculate how long a note should be based on how long it should be played and the note speed
        float length = ( (float)note.Length.TotalSeconds - 0.05F) * grid.noteSpeed;
        // Create each note
        grid.CreateNote(note.Type, length, note.Octave);
    }
}
