using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPlayer : Lasers {

    void Start () {
        speed = 5;
        maxCollisionScreen = 5.5f;
	}
	
	// Update is called once per frame
	void Update () {
        laserMovementUp();
	}
}
