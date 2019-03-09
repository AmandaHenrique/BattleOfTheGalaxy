using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : MonoBehaviour {

    public GameObject[] planets;
    public bool isPlanets;

    void Start () {
        isPlanets = true;
	}
	
	// Update is called once per frame
	void Update () {
        spawnPlanets();

    }

    void spawnPlanets()
    {
        if (isPlanets)
        {
            int number = Random.Range(0, 4);
            int position = Random.Range(1, 3);
            if (position == 1)
            {
                Vector3 local = new Vector3((-8.18f), 8, 0);
                Instantiate(planets[number], local, Quaternion.identity);
                
            }
            if(position == 2)
            {
                Vector3 local = new Vector3((9), 8, 0);
                Instantiate(planets[number], local, Quaternion.identity);

            }



            isPlanets = false;
            StartCoroutine(sleepPlanets());
        }
    }

    IEnumerator sleepPlanets()
    {
        yield return new WaitForSeconds(40);
        isPlanets = true;
    }
}
