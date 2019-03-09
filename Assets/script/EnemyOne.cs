using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : Enemies {

    public GameObject laser;
    AudioSource audioSource;
    public AudioClip soundLaser;
    public GameObject dieAnimation;
    public AudioClip soundExplosion;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        speed = 0.7f;
        life = 8;
        fire = false;
        timeToFire = 5f;
        StartCoroutine(sleepFire());
    }
	

	// Update is called once per frame
	void Update () {
        enemyMovement();
        fireLaser();
        limitScreen();
        enemyDeath();
    }

    void fireLaser()
    {
        if (fire == true)
        {
            Instantiate(laser, transform.position + new Vector3(-1.56f, 0 , 0), Quaternion.identity);
            audioSource.PlayOneShot(soundLaser);
            fire = false;
            StartCoroutine(sleepFire());
        }
        
    }

    public void enemyDeath()
    {
        if (this.life == 0)
        {
            AudioSource.PlayClipAtPoint(soundExplosion, Camera.main.transform.position, 0.5f);
            Instantiate(dieAnimation, transform.position, Quaternion.identity);

            enemyDestroy();
            numberDeaths += 1;

        }
    }
}
