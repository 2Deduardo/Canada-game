﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DropItem() {
        foreach  (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);

        }
    }
}
