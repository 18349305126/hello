﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxRay : MonoBehaviour
{
    public string targetName = "Player";
    void Start() {
        //Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == targetName) {
            //send message to character
        }
        
    }

    private void OnDestroy() {
        Destroy(gameObject, 0f);
    }
}
