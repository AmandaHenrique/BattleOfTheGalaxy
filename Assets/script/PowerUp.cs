using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    float speed;
	void Start () {
        speed = 3;	}
	
	// Update is called once per frame
	void Update () {
        powerUpMovement();

	}

    void powerUpMovement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -6)
        {
            powerUpDestroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                if (this.gameObject.tag == "Hp")
                {
                    player.powerUpHp();
                }
                if (this.gameObject.tag == "Speed")
                {
                    player.powerUpSpeed();
                }
                if (this.gameObject.tag == "FastShoot")
                {
                    player.powerUpFastShoot();
                }
                if (this.gameObject.tag == "Armor")
                {
                    player.powerUpShield();
     
                }
                
            }
            powerUpDestroy();
        }
    }

    void powerUpDestroy()
    {
        Destroy(this.gameObject);
    }
}
