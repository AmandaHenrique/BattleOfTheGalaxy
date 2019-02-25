using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    int life = 5;
    public GameObject laser;

    float speed = 6;
    float vertical;
    float horizontal;

    float maxRigth = 7.9f;
    float maxLeft = -7.9f;
    float maxBottom = -4.2f;
    float maxTop = 4.2f;

    float fireRate = 0.3f;
    float nextFire = 0f;


	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, -4.2f, 0);
        speed = 6;
        life = 5;
	}
	
	// Update is called once per frame
	void Update () {
        playerMovement();
        fireLaser();
	}


    void playerMovement()
    {
        vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(horizontal, vertical, 0);

        if(transform.position.y < maxBottom)
        {
            transform.position = new Vector3(transform.position.x, maxBottom, transform.position.z);
        }
        if(transform.position.y > maxTop)
        {
            transform.position = new Vector3 (transform.position.x, maxTop, transform.position.z);
        }
        if(transform.position.x < maxLeft)
        {
            transform.position = new Vector3(maxLeft, transform.position.y, transform.position.z);
        }
        if(transform.position.x > maxRigth)
        {
            transform.position = new Vector3(maxRigth, transform.position.y, transform.position.z);
        }
    }

    void fireLaser()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(laser, new Vector3(transform.position.x + 0.35f, transform.position.y + 1f, transform.position.z), Quaternion.identity);
                Instantiate(laser, new Vector3(transform.position.x + -(0.35f), transform.position.y + 1f, transform.position.z), Quaternion.identity);
            }  
        }
        
        
    }
}
