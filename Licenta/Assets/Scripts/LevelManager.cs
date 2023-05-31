using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
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
        SceneManager.LoadScene("ArenaSelection");
    }

}