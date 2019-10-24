using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrid : MonoBehaviour
{
    public GameObject Grid;
    public int lowestOctave;
    public int highestOctave;

    void Start()
    {
        float length = (highestOctave + 1) * 7.7F;
        Vector3 scale = new Vector3(1, 1, length / 10);
        Vector3 position = new Vector3(0, 0, (length / 1F) + 3.3F);

        GameObject obj = Instantiate(Grid, position, Quaternion.identity, this.transform);
        obj.transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
