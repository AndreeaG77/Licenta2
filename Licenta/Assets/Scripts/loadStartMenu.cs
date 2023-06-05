using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadStartMenu : MonoBehaviour
{
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
