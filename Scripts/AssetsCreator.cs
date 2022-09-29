using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class AssetsCreator : MonoBehaviour
{
    [Header("SoundBars")]
    public GameObject soundbarsRect;
    public GameObject soundbarsCircle;
    public GameObject soundbarsTriangle;

    [Header("Buildings")]
    public GameObject[] buildingRect;
    public GameObject[] buildingCircle;
    public GameObject[] buildingTriangle;
    public GameObject buildingEmpty;

    [Header("Spawns")]
    public GameObject[] positions;
    public GameObject endLimit;
    private float timer;
    private Vector3 InitialPosition;
    public GameObject SceneManager;

    [Header("Lights")]
    public GameObject lightSpawnerPos;
    public GameObject lightPrefab;

    [Header("Grid")]
    public GameObject gridSpawnerPos;
    public GameObject gridPrefab;

    [Header("Road")]
    public GameObject roadSpawnerPos;
    public GameObject roadPrefab;

    [Header("Cars")]
    public GameObject carPrefab;
    public GameObject CarEmpty;
    public GameObject[] carSpawners;
    public GameObject[] endLimits;


    [Header("Initial Variables")]
    private int row;
    private int movementSpeed;
    private float bias;
    private float timeStep;
    private float timeBeat;
    private float restTime;
    private int spawn;
    private float scale;
    private Color color;


    void Start()
    {
        timer = 0.2f;

      
        StartCoroutine("SpawnLights");
        StartCoroutine("SpawnGrid");
        StartCoroutine("SpawnRoad");
        StartCoroutine("SpawnCars");

    }


    void Update()
    {
        timer -= Time.deltaTime;
;
        if (timer < 0)
        {

            RowSpawns();


            if (GetComponent<SceneManager>().GetSpawn() == 1)
            {
                timer = 1.5f + Random.Range(1f - 1f * 10 / 100, 1f + 1f * 10 / 100);
            }

            else if (GetComponent<SceneManager>().GetSpawn() == 2)
            {
                timer = 1f + Random.Range(0.5f - 0.5f * 10 / 100, 0.5f + 0.5f * 10 / 100); ;
            }

            else if (GetComponent<SceneManager>().GetSpawn() == 3)
            {
                timer = 0.5f + Random.Range(0.25f - 0.25f * 10 / 100, 0.25f + 0.25f * 10 / 100);
            }
        }

    }

    private IEnumerator SpawnRoad()
    {
        while (true)
        {
            GameObject hl = GameObject.Instantiate(roadPrefab, roadSpawnerPos.transform) as GameObject;
            //hl.transform.SetParent(null);
            yield return new WaitForSeconds(5.55f);
        }
    }

    private IEnumerator SpawnCars()
    {
        while (true)
        {
            int i = Random.Range(0, 4);
            
            GameObject sb = GameObject.Instantiate(carPrefab, carSpawners[i].transform) as GameObject;

            if (i < 2)
            {
                sb.gameObject.GetComponent<MapMovement>().SetVelocity(-10);
                sb.transform.Rotate(new Vector3(0f, -180f, 0f));
            }
            else
            {
                sb.GetComponent<MapMovement>().SetVelocity(30);
            }


                
            sb.transform.SetParent(CarEmpty.transform);

            yield return new WaitForSeconds(Random.Range(2f, 2.5f));
        }
        

    }

    private IEnumerator SpawnLights()
    {
        while (true)
        {
            GameObject hl = GameObject.Instantiate(lightPrefab, lightSpawnerPos.transform) as GameObject;
            //hl.transform.SetParent(null);
            yield return new WaitForSeconds(3f);
        }
    }

    private IEnumerator SpawnGrid()
    {
        while (true)
        {
            GameObject g = GameObject.Instantiate(gridPrefab, gridSpawnerPos.transform) as GameObject;
            g.transform.position = gridSpawnerPos.transform.position;
            yield return new WaitForSeconds(2.89f);
        }
    }

    private void RowSpawns()
    {
        if (GetComponent<SceneManager>().GetRows() == 1)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsRect, buildingRect[0]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 2)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsRect, buildingRect[1]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 3)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsRect, buildingRect[2]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 4)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsRect, buildingRect[3]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 5)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsRect, buildingRect[4]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 6)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsRect, buildingRect[5]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 7)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsCircle, buildingCircle[0]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 8)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsCircle, buildingCircle[1]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 9)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsCircle, buildingCircle[2]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 10)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsTriangle, buildingTriangle[0]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 11)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsTriangle, buildingTriangle[1]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 12)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsTriangle, buildingTriangle[2]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 13)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsTriangle, buildingTriangle[3]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 14)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsRect, buildingRect[Random.Range(0, buildingRect.Length)]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 15)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsCircle, buildingCircle[Random.Range(0, buildingCircle.Length)]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 16)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBar(i, soundbarsTriangle, buildingTriangle[Random.Range(0, buildingTriangle.Length)]);
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 17)
        {
            int r = Random.Range(0, 6);
            for (int i = 0; i < 6; i++)
            {
                if (r == 0)
                {
                    if (i < 2)
                    {
                        SpawnBar(i, soundbarsRect, buildingRect[Random.Range(0, buildingRect.Length)]);
                    }else if (i >= 2 && i < 4)
                    {
                        SpawnBar(i, soundbarsCircle, buildingCircle[Random.Range(0, buildingCircle.Length)]);
                    }
                    else if (i >= 4)
                    {
                        SpawnBar(i, soundbarsTriangle, buildingTriangle[Random.Range(0, buildingTriangle.Length)]);
                    }

                }
                else if (r == 1)
                {
                    if (i < 2)
                    {
                        SpawnBar(i, soundbarsRect, buildingRect[Random.Range(0, buildingRect.Length)]);
                    }
                    else if (i >= 2 && i < 4)
                    {
                        SpawnBar(i, soundbarsTriangle, buildingTriangle[Random.Range(0, buildingTriangle.Length)]);
                    }
                    else if (i >= 4)
                    {
                        SpawnBar(i, soundbarsCircle, buildingCircle[Random.Range(0, buildingCircle.Length)]);
                    }
                }
                else if (r == 2)
                {
                    if (i < 2)
                    {
                        SpawnBar(i, soundbarsCircle, buildingCircle[Random.Range(0, buildingCircle.Length)]);
                    }
                    else if (i >= 2 && i < 4)
                    {
                        SpawnBar(i, soundbarsRect, buildingRect[Random.Range(0, buildingRect.Length)]);
                    }
                    else if (i >= 4)
                    {
                        SpawnBar(i, soundbarsTriangle, buildingTriangle[Random.Range(0, buildingTriangle.Length)]);
                    }
                }
                else if (r == 3)
                {
                    if (i < 2)
                    {
                        SpawnBar(i, soundbarsCircle, buildingCircle[Random.Range(0, buildingCircle.Length)]);
                    }
                    else if (i >= 2 && i < 4)
                    {
                        SpawnBar(i, soundbarsTriangle, buildingTriangle[Random.Range(0, buildingTriangle.Length)]);
                    }
                    else if (i >= 4)
                    {
                        SpawnBar(i, soundbarsRect, buildingRect[Random.Range(0, buildingRect.Length)]);
                    }
                }
                else if (r == 4)
                {
                    if (i < 2)
                    {
                        SpawnBar(i, soundbarsTriangle, buildingTriangle[Random.Range(0, buildingTriangle.Length)]);
                    }
                    else if (i >= 2 && i < 4)
                    {
                        SpawnBar(i, soundbarsCircle, buildingCircle[Random.Range(0, buildingCircle.Length)]);
                    }
                    else if (i >= 4)
                    {
                        SpawnBar(i, soundbarsRect, buildingRect[Random.Range(0, buildingRect.Length)]);
                    }
                }
                else if (r == 5)
                {
                    if (i < 2)
                    {
                        SpawnBar(i, soundbarsTriangle, buildingTriangle[Random.Range(0, buildingTriangle.Length)]);
                    }
                    else if (i >= 2 && i < 4)
                    {
                        SpawnBar(i, soundbarsRect, buildingRect[Random.Range(0, buildingRect.Length)]);
                    }
                    else if (i >= 4)
                    { 
                        SpawnBar(i, soundbarsCircle, buildingCircle[Random.Range(0, buildingCircle.Length)]);
                    }
                }
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 18)
        {
            int r = Random.Range(0, 3);
            for (int i = 0; i < 6; i++)
            {
                if (r == 0)
                {
                    SpawnBar(i, soundbarsRect, buildingRect[Random.Range(0, buildingRect.Length)]);
                }
                else if (r == 1)
                {
                    SpawnBar(i, soundbarsCircle, buildingCircle[Random.Range(0, buildingCircle.Length)]);
                }
                else if (r == 2)
                {
                    SpawnBar(i, soundbarsTriangle, buildingTriangle[Random.Range(0, buildingTriangle.Length)]);
                }
            }
        }

        else if (GetComponent<SceneManager>().GetRows() == 19)
        {
            for (int i = 0; i < 6; i++)
            {
                int r = Random.Range(0, 3);

                if (r == 0)
                {
                    SpawnBar(i, soundbarsRect, buildingRect[Random.Range(0, buildingRect.Length)]);
                } else if (r == 1)
                {
                    SpawnBar(i, soundbarsCircle, buildingCircle[Random.Range(0, buildingCircle.Length)]);
                } else if (r == 2)
                {
                    SpawnBar(i, soundbarsTriangle, buildingTriangle[Random.Range(0, buildingTriangle.Length)]);
                }
                
            }
        }
    }

    private void SetUpVariables(GameObject sb)
    {
        sb.transform.GetChild(0).GetComponent<AudioSyncColor>().SetBias(bias);
        sb.GetComponent<AudioSyncScale>().SetBias(bias);

        sb.transform.GetChild(0).GetComponent<AudioSyncColor>().SetTimeBeat(timeBeat);
        sb.GetComponent<AudioSyncScale>().SetTimeBeat(timeBeat);
        sb.transform.GetChild(0).GetComponent<AudioSyncColor>().SetTimeStep(timeStep);
        sb.GetComponent<AudioSyncScale>().SetTimeStep(timeStep);
        sb.transform.GetChild(0).GetComponent<AudioSyncColor>().SetRestTime(restTime);
        sb.GetComponent<AudioSyncScale>().SetRestTime(restTime);
        sb.GetComponent<AudioSyncScale>().SetScale(scale);
    }

    private void SpawnBar(int pos, GameObject bar, GameObject building)
    {

        var adjust = 1f;

        if (pos == 0)
        {
            adjust = 0.5f;
        } else if (pos == 1)
        {
            adjust = 0.5f;
        } else if (pos == 2)
        {
            adjust = 0.75f;
        }
        else if (pos == 3)
        {
            adjust = 0.75f;
        }
        else if (pos == 4)
        {
            adjust = 1f;
        }
        else if (pos == 5)
        {
            adjust = 1f;
        }

        GameObject sb = GameObject.Instantiate(bar, positions[pos].transform) as GameObject;


        //SetUpVariables(sb);
        
        //sb.transform.GetChild(0).GetComponent<AudioSyncColor>().SetBias(SceneManager.GetComponent<SceneManager>().GetBias());
        sb.GetComponent<AudioSyncScale>().SetBias(SceneManager.GetComponent<SceneManager>().GetBias());
        //sb.transform.GetChild(0).GetComponent<AudioSyncColor>().SetTimeBeat(SceneManager.GetComponent<SceneManager>().GetTimeBeat());
        sb.GetComponent<AudioSyncScale>().SetTimeBeat(SceneManager.GetComponent<SceneManager>().GetTimeBeat());
        //sb.transform.GetChild(0).GetComponent<AudioSyncColor>().SetTimeStep(SceneManager.GetComponent<SceneManager>().GetTimeStep());
        sb.GetComponent<AudioSyncScale>().SetTimeStep(SceneManager.GetComponent<SceneManager>().GetTimeStep());
        //sb.transform.GetChild(0).GetComponent<AudioSyncColor>().SetRestTime(SceneManager.GetComponent<SceneManager>().GetRestTime());
        sb.GetComponent<AudioSyncScale>().SetRestTime(SceneManager.GetComponent<SceneManager>().GetRestTime());
        sb.GetComponent<AudioSyncScale>().SetScale(SceneManager.GetComponent<SceneManager>().GetScale() * adjust);  
        
        //sb.transform.SetParent(null);
        //sb.gameObject.GetComponent<MapMovement>().SetEndLimit(endLimit);
        
        //Color
        if (bar == soundbarsTriangle)
        {
            for (int i = 0; i < 3; i++)
            {
                //sb.transform.GetChild(0).GetChild(i).GetComponent<AudioSyncColor>().SetColor(color);
                sb.transform.GetChild(i).GetComponent<AudioSyncColor>().SetColor(SceneManager.GetComponent<SceneManager>().GetColor());
            }
        }
        else
        {
            //sb.transform.GetChild(0).GetComponent<AudioSyncColor>().SetColor(color);
            sb.transform.GetChild(0).GetComponent<AudioSyncColor>().SetColor(SceneManager.GetComponent<SceneManager>().GetColor());
        }

        //Instance
        GameObject bg = GameObject.Instantiate(building, positions[pos].transform) as GameObject;
        bg.transform.SetParent(buildingEmpty.transform);  

        //Rotation Triangle

        if (building == buildingTriangle[0] || building == buildingTriangle[1] || building == buildingTriangle[2] || building == buildingTriangle[3])
        {
            Quaternion rot = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
            sb.transform.rotation = rot;
            bg.transform.rotation = rot;
        }

        SetBuildingHeight(bg, sb);
    }

    
    private void SetBuildingHeight(GameObject bg, GameObject sb)
    {
        if (sb.GetComponent<AudioSyncScale>().GetScale() < 3)
        {
            bg.GetComponent<BuildingScript>().SetHeight(1);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 3 && sb.GetComponent<AudioSyncScale>().GetScale() < 7)
        {
            bg.GetComponent<BuildingScript>().SetHeight(2);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 7 && sb.GetComponent<AudioSyncScale>().GetScale() < 14)
        {
            bg.GetComponent<BuildingScript>().SetHeight(3);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 14 && sb.GetComponent<AudioSyncScale>().GetScale() < 17)
        {
            bg.GetComponent<BuildingScript>().SetHeight(4);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 17 && sb.GetComponent<AudioSyncScale>().GetScale() < 22)
        {
            bg.GetComponent<BuildingScript>().SetHeight(5);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 22 && sb.GetComponent<AudioSyncScale>().GetScale() < 27)
        {
            bg.GetComponent<BuildingScript>().SetHeight(6);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 27 && sb.GetComponent<AudioSyncScale>().GetScale() < 32)
        {
            bg.GetComponent<BuildingScript>().SetHeight(7);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 32 && sb.GetComponent<AudioSyncScale>().GetScale() < 36)
        {
            bg.GetComponent<BuildingScript>().SetHeight(8);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 36 && sb.GetComponent<AudioSyncScale>().GetScale() < 42)
        {
            bg.GetComponent<BuildingScript>().SetHeight(9);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 42 && sb.GetComponent<AudioSyncScale>().GetScale() < 47)
        {
            bg.GetComponent<BuildingScript>().SetHeight(10);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 47 && sb.GetComponent<AudioSyncScale>().GetScale() < 51)
        {
            bg.GetComponent<BuildingScript>().SetHeight(11);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 51 && sb.GetComponent<AudioSyncScale>().GetScale() < 56)
        {
            bg.GetComponent<BuildingScript>().SetHeight(12);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 56 && sb.GetComponent<AudioSyncScale>().GetScale() < 61)
        {
            bg.GetComponent<BuildingScript>().SetHeight(13);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 61 && sb.GetComponent<AudioSyncScale>().GetScale() < 66)
        {
            bg.GetComponent<BuildingScript>().SetHeight(14);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 66 && sb.GetComponent<AudioSyncScale>().GetScale() < 71)
        {
            bg.GetComponent<BuildingScript>().SetHeight(15);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 71 && sb.GetComponent<AudioSyncScale>().GetScale() < 75)
        {
            bg.GetComponent<BuildingScript>().SetHeight(16);
        }
        else if (sb.GetComponent<AudioSyncScale>().GetScale() >= 75)
        {
            bg.GetComponent<BuildingScript>().SetHeight(17);
        }
    }
}
