using UnityEngine;

public class collisionHandler : MonoBehaviour
{

    private MeshRenderer meshRenderer;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("spell"))
        {
            meshRenderer = collision.gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null && meshRenderer.enabled)
            {
                GameObject characterA = gameObject;
                damage damageA = characterA.GetComponent<damage>();

                if (damageA != null)
                {
                    damageA.Combo();
                }
            }
            

        }

        if (collision.gameObject.CompareTag("Enemy")){
            GameObject characterA = gameObject;
            GameObject characterB = collision.gameObject;

            Animator animatorA = characterA.GetComponent<Animator>();
            Animator animatorB = characterB.GetComponent<Animator>();

            if (animatorA != null && animatorB != null)
            {

                AnimatorStateInfo stateInfoA = animatorA.GetCurrentAnimatorStateInfo(0);
                AnimatorStateInfo stateInfoB = animatorB.GetCurrentAnimatorStateInfo(0);


                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("punch"))
                {
                    damage damageA = characterA.GetComponent<damage>();

                    if (damageA != null)
                    {
                        damageA.Punch();
                    }
                }

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("kick"))
                {
                    damage damageA = characterA.GetComponent<damage>();

                    if (damageA != null)
                    {
                        damageA.Punch();
                    }
                }

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("combo"))
                {
                    damage damageA = characterA.GetComponent<damage>();

                    if (damageA != null)
                    {
                        damageA.Punch();
                    }
                }
                
            }
            
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("spell"))
        {
            meshRenderer = collision.gameObject.GetComponent<MeshRenderer>();
            Debug.Log(meshRenderer.enabled);
            if (meshRenderer != null && meshRenderer.enabled)
            {
                GameObject characterA = gameObject;
                damage damageA = characterA.GetComponent<damage>();

                if (damageA != null)
                {
                    damageA.Combo();
                }
            }


        }

        if (collision.gameObject.CompareTag("Enemy")){
            GameObject characterA = gameObject;
            GameObject characterB = collision.gameObject;
            //Debug.Log("xx");
            Animator animatorA = characterA.GetComponent<Animator>();
            Animator animatorB = characterB.GetComponent<Animator>();

            if (animatorA != null && animatorB != null)
            {

                AnimatorStateInfo stateInfoA = animatorA.GetCurrentAnimatorStateInfo(0);
                AnimatorStateInfo stateInfoB = animatorB.GetCurrentAnimatorStateInfo(0);

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("punch"))
                {
                    damage damageA = characterA.GetComponent<damage>();
                    //Debug.Log("00");
                    if (damageA != null)
                    {
                        //Debug.Log("11");
                        damageA.Punch();
                    }
                }

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("kick"))
                {
                    damage damageA = characterA.GetComponent<damage>();

                    if (damageA != null)
                    {
                        damageA.Punch();
                    }
                }

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("combo"))
                {
                    damage damageA = characterA.GetComponent<damage>();

                    if (damageA != null)
                    {
                        damageA.Punch();
                    }
                }
                
            }
            
        }
    }
}
