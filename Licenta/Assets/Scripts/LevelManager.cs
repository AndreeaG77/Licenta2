using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private selectPlayer1 player1;
    private selectPlayer2 player2;
    private int selectedCharacter1;
    private int selectedCharacter2;
    public void Arcane()
    {
        SceneManager.LoadScene("ChooseCharacter1");
    }

    public void Versus()
    {
        SceneManager.LoadScene("ChooseCharacter2");
    }

    public void ArenaSelection()
    {
        GameObject p1 = GameObject.FindWithTag("choosep1");
        GameObject p2 = GameObject.FindWithTag("choosep2");
        player1 = p1.GetComponent<selectPlayer1>();
        selectedCharacter1 = player1.selectedCharacter;
        player2 = p2.GetComponent<selectPlayer2>();
        selectedCharacter2 = player2.selectedCharacter;
        PlayerPrefs.SetInt("selectedCharacter1", selectedCharacter1);
        PlayerPrefs.SetInt("selectedCharacter2", selectedCharacter2);
        SceneManager.LoadScene("ArenaSelection");
    }

}