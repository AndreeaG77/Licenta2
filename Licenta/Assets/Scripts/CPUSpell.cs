using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUSpell : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    private CPUScript enemyScript;
    private GameObject enemy;

    private void Awake()
    {
        enemy = GameObject.FindWithTag("player2");
        enemyScript = enemy.GetComponent<CPUScript>();

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
