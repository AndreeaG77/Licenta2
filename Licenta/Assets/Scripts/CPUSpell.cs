using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUSpell : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    private CPUScript enemyScript;
    private GameObject enemy;
    private CPUScript2 enemyScript2;
    private CPUScript3 enemyScript3;

    private void Awake()
    {
        enemy = GameObject.FindWithTag("player2");
        enemyScript = enemy.GetComponent<CPUScript>();

        enemyScript2 = enemy.GetComponent<CPUScript2>();

        enemyScript3 = enemy.GetComponent<CPUScript3>();
    }

    void Update()
    {
        if (enemyScript != null && enemyScript.enabled)
        {
            if(enemyScript.randomAttack == 2)
            {
                StartCoroutine(EnableSpell());
            }
        }
        if (enemyScript2 != null && enemyScript2.enabled)
        {
            if (enemyScript2.randomAttack == 2)
            {
                StartCoroutine(EnableSpell());
            }
        }
        if (enemyScript3 != null && enemyScript3.enabled)
        {
            if (enemyScript3.randomAttack == 2)
            {
                StartCoroutine(EnableSpell());
            }
        }

    }

    IEnumerator EnableSpell()
    {
        yield return new WaitForSeconds(1f);
        yield return null;
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(2f);
        yield return null;
        meshRenderer.enabled = false;
    }

}
