using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection.Emit;

public class LoadCharacters : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public GameObject spellPrefab1;
    public GameObject spellPrefab2;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPointS1;
    public Transform spawnPointS2;
    public TextMeshProUGUI name1;
    public TextMeshProUGUI name2;

    void Start()
    {
        int selectedCharacter1 = PlayerPrefs.GetInt("selectedCharacter1");
        int selectedCharacter2 = PlayerPrefs.GetInt("selectedCharacter2");
        GameObject prefab1 = characterPrefabs[selectedCharacter1];
        GameObject prefab2 = characterPrefabs[selectedCharacter2];

        // instantiate player 1
        GameObject clone1 = Instantiate(prefab1, spawnPoint1.position, Quaternion.identity);
        clone1.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

        GameObject clone2 = Instantiate(prefab2, spawnPoint2.position, Quaternion.identity);
        clone2.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        // change tag
        clone2.tag = "player2";

        // disable movement, damage and collisionHandler scripts for player 2 option
        if (selectedCharacter1 == 0)
        {
            Transform nexus = clone1.transform.Find("Robot_Soldier_Black");

            player1Movement playerscript1 = nexus.GetComponent<player1Movement>();
            playerscript1.enabled = false;

            damage2 damageS2 = nexus.GetComponent<damage2>();
            damageS2.enabled = false;

            collisionHandler2 collisionH2S = nexus.GetComponent<collisionHandler2>();
            collisionH2S.enabled = false;

            ShootRifle2 rifleS = nexus.GetComponent<ShootRifle2>();
            rifleS.enabled = false;
        }
        else
        {
            player1Movement playerscript1 = clone1.GetComponent<player1Movement>();
            playerscript1.enabled = false;

            damage2 damageS2 = clone1.GetComponent<damage2>();
            damageS2.enabled = false;

            collisionHandler2 collisionH2S = clone1.GetComponent<collisionHandler2>();
            collisionH2S.enabled = false;
        }

        // instantiate spell object for character == 2
        if(selectedCharacter1 == 2)
        {
            GameObject spell1 = Instantiate(spellPrefab1, spawnPointS2.position, Quaternion.identity);
        }
        
        // mirror characters
        if (selectedCharacter1 == 0 || selectedCharacter1 == 2)
        {
            clone1.transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // instantiate player 2
        

        // disable movement, damage and collisionHandler scripts for player 1 option
        if (selectedCharacter2 == 0)
        {
            Transform nexus = clone2.transform.Find("Robot_Soldier_Black");
            player3 playerscript2 = nexus.GetComponent<player3>();
            playerscript2.enabled = false;

            damage damageS1 = nexus.GetComponent<damage>();
            damageS1.enabled = false;

            collisionHandler collisionHS = nexus.GetComponent<collisionHandler>();
            collisionHS.enabled = false;

            ShootRifle rifleS = nexus.GetComponent<ShootRifle>();
            rifleS.enabled = false;
        }
        else
        {
            player3 playerscript2 = clone2.GetComponent<player3>();
            playerscript2.enabled = false;

            damage damageS1 = clone2.GetComponent<damage>();
            damageS1.enabled = false;

            collisionHandler collisionHS = clone2.GetComponent<collisionHandler>();
            collisionHS.enabled = false;
        }

        // instantiate spell object for character == 2
        if (selectedCharacter2 == 2)
        {
            GameObject spell2 = Instantiate(spellPrefab2, spawnPointS1.position, Quaternion.identity);
        }

        // mirror characters
        if (selectedCharacter2 == 1 || selectedCharacter2 == 3)
        {
            clone2.transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // print names of chosen characters
        name1.text = prefab1.name;
        name2.text = prefab2.name;
    }

}
