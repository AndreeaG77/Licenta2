using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectPlayer2 : MonoBehaviour
{
    public GameObject[] options;
    public GameObject player2box;
    public GameObject[] optionsDisplay;
    public GameObject[] namesDisplay;
    public int selectedCharacter;

    void Start()
    {
        //player1box = GetComponent<GameObject>();
        selectedCharacter = 1;
        optionsDisplay[selectedCharacter].SetActive(true);
        namesDisplay[selectedCharacter].SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (selectedCharacter < 2)
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter += 2;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player2box.transform.position.z);
                player2box.transform.position = newPosition;
            }
            else
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter -= 2;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player2box.transform.position.z);
                player2box.transform.position = newPosition;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selectedCharacter % 2 == 0)
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter += 1;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player2box.transform.position.z);
                player2box.transform.position = newPosition;
            }
            else
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter -= 1;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player2box.transform.position.z);
                player2box.transform.position = newPosition;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selectedCharacter % 2 == 0)
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter += 1;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player2box.transform.position.z);
                player2box.transform.position = newPosition;
            }
            else
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter -= 1;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player2box.transform.position.z);
                player2box.transform.position = newPosition;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selectedCharacter < 2)
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter += 2;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player2box.transform.position.z);
                player2box.transform.position = newPosition;
            }
            else
            {
                optionsDisplay[selectedCharacter].SetActive(false);
                namesDisplay[selectedCharacter].SetActive(false);
                selectedCharacter -= 2;
                optionsDisplay[selectedCharacter].SetActive(true);
                namesDisplay[selectedCharacter].SetActive(true);
                Vector3 newPosition = new Vector3(options[selectedCharacter].transform.position.x, options[selectedCharacter].transform.position.y, player2box.transform.position.z);
                player2box.transform.position = newPosition;
            }
        }

    }
}
