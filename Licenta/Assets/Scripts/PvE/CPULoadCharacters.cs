using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection.Emit;

public class CPULoadCharacters : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public GameObject[] characterPrefabsCPU;
    public GameObject spellPrefab1;
    public GameObject spellPrefab2;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPointS1;
    public Transform spawnPointS2;
    public TextMeshProUGUI name1;
    public TextMeshProUGUI name2;
    //private int roundNumber;

    void Start()
    {
        //roundNumber = PlayerPrefs.GetInt("roundNumber");
        int selectedCharacter1 = PlayerPrefs.GetInt("selectedCharacter1");
        int selectedCharacterCPU = PlayerPrefs.GetInt("selectedCharacterCPU");
        GameObject prefab1 = characterPrefabs[selectedCharacter1];
        GameObject prefab2 = characterPrefabsCPU[selectedCharacterCPU];

        // instantiate player 1
        GameObject clone1 = Instantiate(prefab1, spawnPoint1.position, Quaternion.identity);
        clone1.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

        GameObject clone2 = Instantiate(prefab2, spawnPoint2.position, Quaternion.identity);
        clone2.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        // change tag
        clone2.tag = "player2";

        // instantiate spell object for character == 2
        if (selectedCharacter1 == 2)
        {
            GameObject spell1 = Instantiate(spellPrefab1, spawnPointS2.position, Quaternion.identity);
        }

        // mirror characters
        if (selectedCharacter1 == 0 || selectedCharacter1 == 2)
        {
            clone1.transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // instantiate spell object for character == 2
        if (selectedCharacterCPU == 2)
        {
            GameObject spell2 = Instantiate(spellPrefab2, spawnPointS1.position, Quaternion.identity);
        }

        // mirror characters
        if (selectedCharacterCPU == 1 || selectedCharacterCPU == 3)
        {
            clone2.transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // print names of chosen characters
        name1.text = prefab1.name;
        name2.text = prefab2.name;
    }

}
