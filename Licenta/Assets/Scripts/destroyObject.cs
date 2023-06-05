using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour
{
    private LevelManager2 levelManager2;
    private void Start()
    {

        levelManager2 = FindObjectOfType<LevelManager2>();
        Destroy(levelManager2);
    }


}
