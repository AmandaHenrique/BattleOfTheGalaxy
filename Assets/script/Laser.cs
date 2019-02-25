using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    float speed = 6;
    float maxTop = 5.5f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        laserMovement();
    }

    void laserMovement()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > maxTop)
        {
            Destroy(this.gameObject);
        }
    }

    
}
