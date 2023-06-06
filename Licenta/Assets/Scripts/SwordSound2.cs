using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSound2 : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            source.clip = clip;
            source.PlayOneShot(source.clip);
        }

        if (Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.L))
        {
            source.clip = clip;
            source.PlayOneShot(source.clip);
        }
    }
}
