using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    [Header("Grid")]
    public GameObject gridParent;

    [Header("Scene Manager")]
    public GameObject sceneManager;
    private SceneManager sm;


    void Start()
    {
        sm = sceneManager.GetComponent<SceneManager>();

        foreach (Transform c in this.transform)
        {
            c.transform.GetChild(0).GetComponent<AudioSyncScale>().SetBias(Random.Range(1f, 6f));
            c.transform.GetChild(0).GetComponent<AudioSyncScale>().SetTimeStep(Random.Range(0.15f, 1f));
            c.transform.GetChild(0).GetComponent<AudioSyncScale>().SetTimeBeat(Random.Range(0.05f, 0.3f));
            c.transform.GetChild(0).GetComponent<AudioSyncScale>().SetRestTime(Random.Range(0.2f, 1f));
            c.transform.GetChild(0).GetComponent<AudioSyncScale>().SetScale(77);
        }
    }

    
    void Update()
    {
        ChangeBackgroundColor();
        ChangeGridColor();
    }

    private void ChangeGridColor()
    {
        foreach(Transform c in gridParent.transform)
        {
            c.GetComponent<Renderer>().material.SetColor("_EmissionColor", sm.GetBgColor());

            foreach(Transform child in c)
            {
                for (int i = 0; i <= 3; i++)
                {
                    child.GetComponent<Renderer>().material.SetColor("_EmissionColor", sm.GetBgColor());
                }
            }
        }
    }

    private void ChangeBackgroundColor()
    {
        foreach (Transform c in this.transform)
        {
            c.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_EmissionColor", sm.GetBgColor());
        }
    }
}
