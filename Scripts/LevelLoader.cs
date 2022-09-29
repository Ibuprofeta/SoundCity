using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public GameObject firstMenu;
    public GameObject menu;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Road")
        {
            firstMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Road")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menu.activeInHierarchy) menu.SetActive(false);
                else menu.SetActive(true);
            }

            if (!audio.isPlaying)
            {
                ReturnMenu();
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Menu")
        {
            if (menu.activeInHierarchy) menu.SetActive(false);
        }
        StartCoroutine(LoadLevel(1));
    }

    public void ReturnMenu()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Road")
        {
            if (menu.activeInHierarchy) menu.SetActive(false);
        }

        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(2.5f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(levelIndex);
    }
}
