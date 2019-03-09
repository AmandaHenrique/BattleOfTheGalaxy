using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour{

    public float speed;
    public float life;
    public float timeToFire;
    public bool fire;
    public static int numberDeaths;

    public void enemyMovement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                life -= 1;
            }
        }
        if(other.tag == "LaserPlayer")
        {
            life -= 1;
            Destroy(other.gameObject);
        }
    }

    

    public void enemyDestroy()
    {
        Destroy(this.gameObject);
    }

    public void limitScreen()
    {
        if (transform.position.y < -7)
        {
            enemyDestroy();
        }
    }
    
    public IEnumerator sleepFire()
    {
        yield return new WaitForSeconds(timeToFire);
        fire = true;
    }
}
