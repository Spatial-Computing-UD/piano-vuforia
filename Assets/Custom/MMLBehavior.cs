using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MMLBehavior : MonoBehaviour
{

    MMLTest player;

    // Start is called before the first frame update
    void Start()
    {
        player = new MMLTest();
        player.FromFile("Assets\\Custom\\test.mml");
        player.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Playing)
        {
            player.Update();

            System.Threading.Thread.Sleep(1);
        }
    }
}
