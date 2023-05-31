using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectPlayer1 : MonoBehaviour
{
    public GameObject[] options;
    public GameObject player1box;
    public GameObject[] optionsDisplay;
    public GameObject[] namesDisplay;
    private int selectedCharacter;

    void Start()
    {
        //player1box = GetComponent<GameObject>();
        selectedCharacter = 0;
        optionsDisplay[selectedCharacter].SetActive(true);
        namesDisplay[selectedCharacter].SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) { 
            if (selectedCharacter < 2)
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter += 2;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player1box.transform.position.z);
                player1box.transform.position = newPosition;
            }
            else
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter -= 2;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player1box.transform.position.z);
                player1box.transform.position = newPosition;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (selectedCharacter % 2 == 0)
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter += 1;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player1box.transform.position.z);
                player1box.transform.position = newPosition;
            }
            else
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter -= 1;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player1box.transform.position.z);
                player1box.transform.position = newPosition;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (selectedCharacter % 2 == 0)
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter += 1;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player1box.transform.position.z);
                player1box.transform.position = newPosition;
            }
            else
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter -= 1;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player1box.transform.position.z);
                player1box.transform.position = newPosition;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (selectedCharacter < 2)
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter += 2;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player1box.transform.position.z);
                player1box.transform.position = newPosition;
            }
            else
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter -= 2;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player1box.transform.position.z);
                player1box.transform.position = newPosition;
            }
        }

    }
}
