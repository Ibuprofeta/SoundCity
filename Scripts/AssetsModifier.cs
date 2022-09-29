using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsModifier : MonoBehaviour
{
    [Header("Cars")]
    public GameObject carsParent;

    [Header("Scene Manager")]
    private SceneManager sm;

    void Start()
    {
        sm = GetComponent<SceneManager>();
    }

    void Update()
    {
        ChangeCarColor();
    }

    private void ChangeCarColor()
    { 
        if (carsParent.transform.childCount > 0)
        {
            foreach (Transform c in carsParent.transform)
            {
                c.transform.GetChild(2).GetComponent<Renderer>().materials[2].SetColor("_EmissionColor", sm.GetBgColor());
            }
        }
    }
}
