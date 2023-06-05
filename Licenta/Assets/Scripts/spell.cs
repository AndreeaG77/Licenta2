using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    private Rigidbody bodyspell;
    private GameObject player2;
    private Transform playerT;
    private Transform spellT;

    private void Awake()
    {
        bodyspell = GetComponent<Rigidbody>();
        player2 = GameObject.FindWithTag("player2");
        playerT = player2.transform;
        spellT = transform;
    }

    void Update()
    {
        float Xcoord = playerT.position.x;
        spellT.position = new Vector3(Xcoord, spellT.position.y, spellT.position.z);

        if(Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.G)){
            StartCoroutine(EnableSpell());
        }
        
    }

    IEnumerator EnableSpell()
    {;
        yield return new WaitForSeconds(1f);
        yield return null;
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(2f);
        yield return null;
        meshRenderer.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall")){
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
