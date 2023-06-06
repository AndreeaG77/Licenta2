using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRifle2 : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public AudioSource source;
    public AudioClip clip;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            source.clip = clip;
            source.PlayOneShot(source.clip);
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
