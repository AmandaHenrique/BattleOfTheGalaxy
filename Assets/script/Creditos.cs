using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour {

    public GameObject LoadScene;
    public LoadScene loadScene;

	// Use this for initialization
	void Start () {
        loadScene = LoadScene.GetComponent<LoadScene>();
        StartCoroutine(sleepAnimation());
	}
	
    IEnumerator sleepAnimation()
    {
        yield return new WaitForSeconds(17);
        loadScene.loadScene("MENU");
    }

}
