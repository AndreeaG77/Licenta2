using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaSelect : MonoBehaviour
{
    //public GameObject[] options;
    public GameObject[] optionsDisplay;
    public GameObject[] namesDisplay;
    private int selectedArena;
    private string[] arenas;
    private System.Random random;


    void Start()
    {
        selectedArena = 0;
        optionsDisplay[selectedArena].SetActive(true);
        namesDisplay[selectedArena].SetActive(true);
        arenas = new string[] { "GatesOfHell", "TempleOfGods", "TempleOfSouls" };
        random = new System.Random();

    }

    public void NextOptions()
    {
        if(selectedArena <3)
        {
            optionsDisplay[selectedArena].SetActive(false);
            namesDisplay[selectedArena].SetActive(false);
            selectedArena++;
            optionsDisplay[selectedArena].SetActive(true);
            namesDisplay[selectedArena].SetActive(true);
        }
        else
        {
            optionsDisplay[selectedArena].SetActive(false);
            namesDisplay[selectedArena].SetActive(false);
            selectedArena = 0;
            optionsDisplay[selectedArena].SetActive(true);
            namesDisplay[selectedArena].SetActive(true);
        }
    }

    public void PreviousOptions()
    {
        if (selectedArena > 0)
        {
            optionsDisplay[selectedArena].SetActive(false);
            namesDisplay[selectedArena].SetActive(false);
            selectedArena--;
            optionsDisplay[selectedArena].SetActive(true);
            namesDisplay[selectedArena].SetActive(true);
        }
        else
        {
            optionsDisplay[selectedArena].SetActive(false);
            namesDisplay[selectedArena].SetActive(false);
            selectedArena = optionsDisplay.Length-1;
            optionsDisplay[selectedArena].SetActive(true);
            namesDisplay[selectedArena].SetActive(true);
        }
    }

    public void LoadArena()
    {
        if(selectedArena != 3)
        {
            SceneManager.LoadScene(arenas[selectedArena]);
        }
        else
        {
            int randomNumber = random.Next(0, 3);
            SceneManager.LoadScene(arenas[randomNumber]);
        }
        
    }
}
