using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class CPUScoreManagement : MonoBehaviour
{
    public GameObject point1p1;
    public GameObject point2p1;
    public GameObject point1p2;
    public GameObject point2p2;
    public Image healthBarI1;
    private healthBar healthScript1;
    public Image healthBarI2;
    private healthBar2 healthScript2;
    private int score1 = 0;
    private int score2 = 0;
    private GameObject player1;
    private GameObject player2;
    private string playerName1;
    private string playerName2;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI name1;
    public TextMeshProUGUI name2;
    Animator animatorp1;
    Animator animatorp2;
    private bool isCalculatingScore1 = false;
    private bool isCalculatingScore2 = false;
    private bool forcedEnding = false;
    public TextMeshProUGUI countDown;
    public GameObject cd;
    private CountDown cdScript;
    public GameObject afterGameMenu;
    private LevelManager2 levelManager2;
    public GameObject playerUI;

    private void Start()
    {
        healthScript1 = healthBarI1.GetComponent<healthBar>();
        healthScript2 = healthBarI2.GetComponent<healthBar2>();
        player1 = GameObject.FindWithTag("player1");
        player2 = GameObject.FindWithTag("player2");
        playerName1 = name1.text;
        playerName2 = name2.text;
        animatorp1 = player1.GetComponent<Animator>();
        animatorp2 = player2.GetComponent<Animator>();
        cdScript = cd.GetComponent<CountDown>();
        levelManager2 = FindObjectOfType<LevelManager2>();

        StartCoroutine(startGame());
    }

    private void Update()
    {
        if (!isCalculatingScore1 && healthScript1.health <= 0)
        {
            StartCoroutine(calculateScore1());
        }

        if (!isCalculatingScore2 && healthScript2.health2 <= 0)
        {
            StartCoroutine(calculateScore2());
        }

        if (!forcedEnding && countDown.text == "0")
        {
            StartCoroutine(forceEnding());
        }

    }

    IEnumerator forceEnding()
    {
        forcedEnding = true;
        if (healthScript1.health < healthScript2.health2)
        {
            //countDown.text = "10";
            yield return StartCoroutine(calculateScore1());

        }
        else if (healthScript1.health > healthScript2.health2)
        {
            //countDown.text = "10";
            yield return StartCoroutine(calculateScore2());
            //countDown.text = "10";
        }
        else
        {
            int randomValue = Random.Range(1, 3);
            if (randomValue == 1)
            {
                yield return StartCoroutine(calculateScore1());
            }
            else
            {
                yield return StartCoroutine(calculateScore2());
            }
        }
        //countDown.text = "10";
        forcedEnding = false;
    }
    IEnumerator calculateScore1()
    {
        isCalculatingScore1 = true;
        animatorp1.SetTrigger("death");
        score2 += 1;
        if (score2 == 1)
        {
            point1p2.SetActive(true);
            yield return StartCoroutine(endRound(playerName2, score1 + score2 + 1));
        }
        if (score2 == 2)
        {
            point2p2.SetActive(true);
            yield return StartCoroutine(endGame(playerName2));
        }
        //yield return resetCountdown();
        //yield return null;
        isCalculatingScore1 = false;
    }

    IEnumerator calculateScore2()
    {
        isCalculatingScore2 = true;
        Debug.Log("ooo");
        animatorp2.SetTrigger("death");
        score1 += 1;
        if (score1 == 1)
        {
            point1p1.SetActive(true);
            yield return StartCoroutine(endRound(playerName1, score2 + score1 + 1));
        }
        if (score1 == 2)
        {
            point2p1.SetActive(true);
            yield return StartCoroutine(endGame(playerName1));
        }

        //yield return null;
        isCalculatingScore2 = false;
    }
    IEnumerator startGame()
    {
        cdScript.PauseCountdown();
        winText.text = "Round 1";
        winText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        cdScript.ResumeCountdown();
        yield return new WaitForSeconds(1f);
        winText.gameObject.SetActive(false);

    }
    IEnumerator endRound(string winner, int score)
    {
        cdScript.PauseCountdown();
        winText.text = winner + " wins";
        winText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        winText.text = "Round " + score.ToString();
        yield return new WaitForSeconds(2f);
        winText.gameObject.SetActive(false);
        healthScript2.health2 = healthBar2.MAX_HEALTH;
        healthScript1.health = healthBar.MAX_HEALTH;
        animatorp1.SetTrigger("idle");
        animatorp2.SetTrigger("idle");
        cdScript.resetCountdown2();
        cdScript.ResumeCountdown();

    }

    IEnumerator endGame(string winner)
    {
        winText.text = winner + " wins";
        winText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        winText.gameObject.SetActive(false);
        //afterGameMenu.SetActive(true);
        if (score2 == 2)
        {
            SceneManager.LoadScene("FailedScene");
        }
        else
        {
            playerUI.SetActive(false);
            afterGameMenu.SetActive(true);
            yield return new WaitForSeconds(4f);
            levelManager2.LoadNextScene();
        }

    }
}