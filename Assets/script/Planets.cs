using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour {
    float speed;
	// Use this for initialization
	void Start () {
        speed = 0.3f;	
	}
	
	// Update is called once per frame
	void Update () {
        planetMovement();
        planetDestroy();
	}

    void planetMovement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void planetDestroy()
    {
        if(transform.position.y < -9)
        {
            Destroy(this.gameObject);
        }
    }
}
