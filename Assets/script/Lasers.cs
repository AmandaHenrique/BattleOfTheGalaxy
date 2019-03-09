using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour {

    public float speed;
    public float maxCollisionScreen;
    
    public void laserMovementUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > maxCollisionScreen)
        {
            Destroy(this.gameObject);
        }
    }

    public void laserMovementDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < maxCollisionScreen)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }



}
