using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public GameObject[] tires;

    public GameObject cube;
    
    void Start()
    {
        cube.GetComponent<AudioSyncColor>().SetBias(Random.Range(1f, 6f));
        cube.GetComponent<AudioSyncColor>().SetTimeStep(Random.Range(0.15f, 1f));
        cube.GetComponent<AudioSyncColor>().SetTimeBeat(Random.Range(0.05f, 0.3f));
        cube.GetComponent<AudioSyncColor>().SetRestTime(Random.Range(0.2f, 1f));
    }

    void Update()
    {
        foreach (GameObject g in tires)
        {
            g.transform.Rotate(new Vector3(0f, 0f, 1000f) * Time.deltaTime);
        }
    }
}
