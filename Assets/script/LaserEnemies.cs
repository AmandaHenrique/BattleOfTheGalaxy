using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemies : Lasers {

	void Start () {
        speed = 4f;
        maxCollisionScreen = -4.8f;
           
	}
	
	// Update is called once per frame
	void Update () {
        laserMovementDown();
	}
}
