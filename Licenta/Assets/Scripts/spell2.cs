using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell2 : MonoBehaviour
{
    //[SerializeField] private Rigidbody bodyplayer;
    [SerializeField] private MeshRenderer meshRenderer;
    //[SerializeField] private BoxCollider boxCollider;
    //private BoxCollider boxCollider;
    private Rigidbody bodyspell;
    private GameObject player1;
    private Transform playerT;
    private Transform spellT;

    private void Awake()
    {
        bodyspell = GetComponent<Rigidbody>();
        player1 = GameObject.FindWithTag("player1");
        playerT = player1.transform;
        spellT = transform;
    }

    void Update()
    {
        float Xcoord = playerT.position.x;
        spellT.position = new Vector3(Xcoord, spellT.position.y, spellT.position.z);

        if (Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(EnableSpell());
        }

    }

    IEnumerator EnableSpell()
    {
        ;
        yield return new WaitForSeconds(1f);
        yield return null;
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(2f);
        yield return null;
        meshRenderer.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
