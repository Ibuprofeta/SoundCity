using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{

    public GameObject[] storeys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHeight(int h)
    {
        for (int i = 0; i < storeys.Length; i++)
        {
            if (i < h) storeys[i].SetActive(true);
            else storeys[i].SetActive(false);
        }
    
    }
}
