using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    public float velocity;
    public GameObject EndLimit;
    public GameObject StartLimit;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0f, 0f, -velocity) * Time.deltaTime;

        if (gameObject.tag == "Road")
        {
            if (transform.position.z < EndLimit.transform.position.z)
            {
                Destroy(gameObject);
            }

        }

        else if (gameObject.tag == "Building")
        {
            if (transform.position.z < EndLimit.transform.position.z)
            {
                Destroy(gameObject);
            } 
        }

        else if (gameObject.tag == "Car")
        {
            if (transform.position.z < -80f || transform.position.z > 170f) Destroy(gameObject);
        }

        else if (gameObject.tag == "Grid")
        {
            if (transform.position.z < EndLimit.transform.position.z)
            {
                Destroy(gameObject);
            }
        }


    }

    public void SetVelocity (float v)
    {
        velocity = v;
    }

    public void SetEndLimit(GameObject e)
    {
        EndLimit = e;
    }
}
