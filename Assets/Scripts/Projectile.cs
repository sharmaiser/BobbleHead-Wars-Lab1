﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
