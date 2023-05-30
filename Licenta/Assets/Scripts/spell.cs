using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{
    [SerializeField] private Rigidbody bodyplayer;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private BoxCollider boxCollider;
    //private BoxCollider boxCollider;
    private Rigidbody bodyspell;
    private Transform playerT;
    private Transform spellT;

    private void Awake()
    {
        bodyspell = GetComponent<Rigidbody>();
        //BoxCollider boxCollider = GetComponent<BoxCollider>();
        
        //spellObject = GetComponent<GameObject>();
        playerT = bodyplayer.transform;
        spellT = transform;
    }

    void Update()
    {
        float Xcoord = playerT.position.x;
        spellT.position = new Vector3(Xcoord, spellT.position.y, spellT.position.z);

        if(Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.G)){
            //Debug.Log("primultest");
            StartCoroutine(EnableSpell());
        }
        
    }

    IEnumerator EnableSpell()
    {
        //Debug.Log("xxxxx");
        yield return new WaitForSeconds(1f);
        yield return null;
        meshRenderer.enabled = true;
        //boxCollider.enabled = true;
        //spellObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        yield return null;
        //spellObject.SetActive(false);
        meshRenderer.enabled = false;
        //boxCollider.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall")){
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
