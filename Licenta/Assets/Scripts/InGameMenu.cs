using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{

    private static bool isPaused = false;

    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject controls;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    public void resumeGame()
    {
        inGameMenu.SetActive(false);
        controls.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void pauseGame()
    {
        inGameMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void loadStartMenu()
    {
        resumeGame();
        SceneManager.LoadScene("StartMenu");
    }

    public void loadControls()
    {
        inGameMenu.SetActive(false);
        controls.SetActive(true);
    }

    public void loadInGameMenu()
    {
        inGameMenu.SetActive(true);
        controls.SetActive(false);
    }

}
