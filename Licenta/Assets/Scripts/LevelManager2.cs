using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LevelManager2 : MonoBehaviour
{
    private List<string> arenas = new List<string> { "CPUGatesOfHell", "CPUTempleOfGods", "CPUTempleOfSouls" };
    private System.Random random = new System.Random();
    private int currentSceneIndex = 0;
    private int currentCharacterIndex = 0;
    private selectPlayer1 player1;
    private int selectedCharacter1;
    private List<int> characters = new List<int> { 0,1,2,3 };

    private void Start()
    {
        ShuffleSceneOrder();
        ShuffleCharactersOrder();
        DontDestroyOnLoad(gameObject);
        //LoadNextScene();
    }

    private void ShuffleSceneOrder()
    {
        // Fisher-Yates shuffle algorithm
        int n = arenas.Count;
        while (n > 1)
        {
            n--;
            int randomIndex = random.Next(n + 1);
            string aux = arenas[randomIndex];
            arenas[randomIndex] = arenas[n];
            arenas[n] = aux;
        }
    }

    private void ShuffleCharactersOrder()
    {
        // Fisher-Yates shuffle algorithm
        int n = characters.Count;
        while (n > 1)
        {
            n--;
            int randomIndex = random.Next(n + 1);
            int aux = characters[randomIndex];
            characters[randomIndex] = characters[n];
            characters[n] = aux;
        }
    }

    public void LoadNextScene()
    {
        //Debug.Log("xxx");
        if(currentSceneIndex == 0)
        {
            GameObject p1 = GameObject.FindWithTag("choosep1");
            player1 = p1.GetComponent<selectPlayer1>();
            selectedCharacter1 = player1.selectedCharacter;
            PlayerPrefs.SetInt("selectedCharacter1", selectedCharacter1);
        }

        if (currentCharacterIndex < characters.Count)
        {
            if (characters[currentCharacterIndex] == selectedCharacter1)
            {
                currentCharacterIndex++;
            }
            if (currentCharacterIndex < characters.Count)
            {
                int nextCharacter = characters[currentCharacterIndex];
                PlayerPrefs.SetInt("selectedCharacterCPU", nextCharacter);
                currentCharacterIndex++;
            }
                
        }

        if (currentSceneIndex < arenas.Count)
        {
            string nextScene = arenas[currentSceneIndex];
            SceneManager.LoadScene(nextScene);
            currentSceneIndex++;
        }
        else
        {
            SceneManager.LoadScene("FinalScene");
        }
    }
}