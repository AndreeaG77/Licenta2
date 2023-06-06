using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSound1 : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            source.clip = clip;
            source.PlayOneShot(source.clip);
        }

        if (Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.G))
        {
            source.clip = clip;
            source.PlayOneShot(source.clip);
        }
    }
}
