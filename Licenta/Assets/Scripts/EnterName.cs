using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterName : MonoBehaviour
{
    private string input;

    public void ReadInput(string s)
    {
        input = s;
    }

    public void LoadCharacterSelection()
    {
        PlayerPrefs.SetString("playerName", input);
        SceneManager.LoadScene("ChooseCharacter1");
    }
}
