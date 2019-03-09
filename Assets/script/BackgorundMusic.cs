using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgorundMusic : MonoBehaviour {

    AudioSource audioSource;
    float normalVolume = 0.5f;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = normalVolume;
	}
	
	// Update is called once per frame
	void Update () {
        volume();
	}

    void volume()
    {
        if (Player.isPause)
        {
            audioSource.volume = 0.2f;
        }
        if (Player.creditos)
        {
            audioSource.volume = 0.2f;
        }
        if(Player.isPause == false)
        {
            audioSource.volume = normalVolume;
        }
    }
}
