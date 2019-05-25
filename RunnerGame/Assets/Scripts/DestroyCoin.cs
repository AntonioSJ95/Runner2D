﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Obstacle")
        {
            Destroy(col.gameObject);
        }
    }
}
