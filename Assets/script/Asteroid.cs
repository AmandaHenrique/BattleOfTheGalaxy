using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip soundAsteroid;
    float speed;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        speed = 5;
	}
	
	// Update is called once per frame
	void Update () {
        asteroideMovement();
        soundFlame();

    }

    void asteroideMovement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if(transform.position.y < -8)
        {
            Destroy(this.gameObject);
        }
    }

    void soundFlame()
    {
        if(audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(soundAsteroid);
        }
       
    }
}
