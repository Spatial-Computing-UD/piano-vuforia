using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKeys : MonoBehaviour
{

    public int lowestOctave = 0;
    public int highestOctave = 7;

    public GameObject key;
    readonly char[] keys = { 'c', 'd', 'e', 'f', 'g', 'a', 'b' };
    readonly int[] sharps = { 0, 1, 3, 4, 5 };

    void Start()
    {
        for(int octave = lowestOctave; octave < highestOctave + 1; octave++)
        {
            // Create empty game object to hold the current octave
            int octaveTemp = octave + 1;
            string name = "Octave " + octaveTemp.ToString();
            GameObject currentOctave = new GameObject(name);
            currentOctave.transform.SetParent(transform);
            currentOctave.transform.position = transform.position;
            currentOctave.transform.position += new Vector3(0, 1.5F, (7.7F * octave));

            // Create each note in the octave, assign names, and load audio clips
            for(int note = 0; note < 7; note++)
            {
                float zPosition = note + (note * 0.1F);
                Vector3 position = new Vector3(0, 0, zPosition);
                position += currentOctave.transform.position;

                GameObject currentKey = Instantiate(key, position, Quaternion.identity, currentOctave.transform);
                currentKey.name = keys[note].ToString();
                currentKey.GetComponent<PlayNoteSound>().noteType = keys[note];

                string audioName = currentKey.name.ToUpper() + octaveTemp.ToString();
                currentKey.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load("piano\\" + audioName);
            }

            // Create sharp notes
            for (int note = 0; note < 5; note++)
            {
                float zPosition = (sharps[note] + (sharps[note] * 0.1F)) + 0.55F;
                float xPosition = -0.6125F;
                float yPosition = -0.5F;
                Vector3 position = new Vector3(xPosition, yPosition, zPosition);
                position += currentOctave.transform.position;

                GameObject currentKey = Instantiate(key, position, Quaternion.identity, currentOctave.transform);
                currentKey.transform.localScale = new Vector3(0.25F, 2F, 0.75F);
                currentKey.name = keys[sharps[note]].ToString() + '#'.ToString();
                currentKey.GetComponent<PlayNoteSound>().noteType = keys[sharps[note]];
                currentKey.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 0)); 

                string audioName = currentKey.name.ToUpper() + octaveTemp.ToString();
                currentKey.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("piano\\" + audioName);
            }
        }
    }

    
}
