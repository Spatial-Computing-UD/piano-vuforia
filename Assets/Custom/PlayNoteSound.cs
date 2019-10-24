using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNoteSound : MonoBehaviour
{

    public char noteType;
    private AudioSource noteSound;

    void Start()
    {
        noteSound = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        noteSound.Play(0);
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        noteSound.Stop();
        Destroy(other.gameObject);
    }

    void Update()
    {
        
    }
}
