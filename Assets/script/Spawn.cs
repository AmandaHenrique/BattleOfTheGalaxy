using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] powerUps;
    public GameObject[] enemies;
    public static bool spawnPowerups;
    public static int numberDeaths;
    public bool secondFase;
    public float sleepEnemies;
    public static bool spawnEnemies;

    public int currentFase;

    UI ui;


    void Start () {
        spawnPowerups = false;
        StartCoroutine(sleepPowerUp());
        Enemies.numberDeaths = 0;
        secondFase = false;
        spawnEnemies = false;
        sleepEnemies = 5;
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        currentFase = 1;
        ui.currentfaseOn();
        StartCoroutine(sleepSpawnEnemies());
    }
	
	// Update is called once per frame
	void Update () {
        ui.currentTextFase(currentFase);
        SpawnPowerUps();
        numberDeaths= Enemies.numberDeaths;
        SpawnEnemies();
    }

    void SpawnPowerUps()
    {
        if(spawnPowerups == true)
        {
            int number = Random.Range(0, 4);
            Vector3 local = new Vector3(Random.Range(7.9f, -7.9f),6 ,0);
            Instantiate(powerUps[number], local, Quaternion.identity);
            spawnPowerups = false;
            StartCoroutine(sleepPowerUp());

        }
    }

    void SpawnEnemies()
    {
        if(Player.isPause == false)
        {
            if (spawnEnemies == true)
            {
                if (numberDeaths <= 9)
                {
                    Vector3 local = new Vector3(Random.Range(7.5f, -7.5f), 6, 0);
                    Instantiate(enemies[0], local, Quaternion.identity);
                    spawnEnemies = false;
                    StartCoroutine(sleepSpawnEnemies()); 
                }
                if (numberDeaths > 9 && numberDeaths <= 15)
                {
                    currentFase = 2;
                    sleepEnemies = 3;
                    int number = Random.Range(0, 2);
                    Vector3 local = new Vector3(Random.Range(7.5f, -7.5f), 6, 0);
                    Instantiate(enemies[number], local, Quaternion.identity);
                    spawnEnemies = false;
                    StartCoroutine(sleepSpawnEnemies());
                    
                }
                if (numberDeaths > 15)
                {
                    int number = Random.Range(0, 3);
                    Vector3 local = new Vector3(Random.Range(7.5f, -7.5f), 6, 0);
                    Instantiate(enemies[number], local, Quaternion.identity);
                    spawnEnemies = false;
                    StartCoroutine(sleepSpawnEnemies());
                    currentFase = 3;
                }
            }
        }
        
        
    }


    IEnumerator sleepSpawnEnemies()
    {
        yield return new WaitForSeconds(sleepEnemies);
        spawnEnemies = true;
    }

    IEnumerator sleepPowerUp()
    {
        yield return new WaitForSeconds(30);
        spawnPowerups = true;
    }
}
