using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : Enemies {

    public GameObject laser;
    AudioSource audioSource;
    public AudioClip soundLaser;
    public GameObject dieAnimation;
    public AudioClip soundExplosion;

    void Start () {
        audioSource = GetComponent<AudioSource>();
        life = 4;
        speed = 1.5f;
        fire = false;
        timeToFire = 4f;
        StartCoroutine(sleepFire());
    }
	
	void Update () {
        enemyMovement();
        enemyDeath();
        fireLaser();
        limitScreen();

    }

    void fireLaser()
    {
        if (fire == true)
        {      
            Instantiate(laser, transform.position + new Vector3(-1.6f, 0.2f, 0), Quaternion.identity);
            audioSource.PlayOneShot(soundLaser);
            fire = false;
            StartCoroutine(sleepFire());
            
        }
    }

    public void enemyDeath()
    {
        if (this.life == 0)
        {
            Instantiate(dieAnimation, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(soundExplosion, Camera.main.transform.position, 0.5f); enemyDestroy();
            numberDeaths += 1;

        }
    }

    IEnumerator laserDistance()
    {
        yield return new WaitForSeconds(1.5f);
    }



}
