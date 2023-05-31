using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection.Emit;

public class LoadCharacters : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public TextMeshProUGUI name1;
    public TextMeshProUGUI name2;

    void Start()
    {
        int selectedCharacter1 = PlayerPrefs.GetInt("selectedCharacter1");
        int selectedCharacter2 = PlayerPrefs.GetInt("selectedCharacter2");
        GameObject prefab1 = characterPrefabs[selectedCharacter1];
        GameObject prefab2 = characterPrefabs[selectedCharacter2];
        GameObject clone1 = Instantiate(prefab1, spawnPoint1.position, Quaternion.identity);
        clone1.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        if(selectedCharacter1 == 0 || selectedCharacter1 == 2)
        {
            clone1.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        GameObject clone2 = Instantiate(prefab2, spawnPoint2.position, Quaternion.identity);
        clone2.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        if (selectedCharacter2 == 1 || selectedCharacter2 == 3)
        {
            clone2.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        name1.text = prefab1.name;
        name2.text = prefab2.name;
    }

}
