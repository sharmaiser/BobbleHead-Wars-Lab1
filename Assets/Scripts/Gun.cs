using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform launchPosition;
   
    void fireBullet()
    {
        // It will create bullets based on the prefab
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        // The bullets position in respect to the launcher.
        bullet.transform.position = launchPosition.position;
        // This will make bullet travel at a constant speed
        bullet.GetComponent<Rigidbody>().velocity =
        transform.parent.forward * 100;
    }

    void Start()
    {

    }

    void Update()
    {
        fireBullet();

        // To add delay in between shooting bullets.
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsInvoking("fireBullet"))
            {
                InvokeRepeating("fireBullet", 0f, 0.1f);
            }
        }
        fireBullet();
        // To make the bullet fire once per round.
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("fireBullet");
        }
    }
}
