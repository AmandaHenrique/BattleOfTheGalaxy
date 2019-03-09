using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int life = 5;
    public GameObject laser;

    public float speed = 6;
    float vertical;
    float horizontal;

    float maxRigth = 7.9f;
    float maxLeft = -7.9f;
    float maxBottom = -3.85f;
    float maxTop = 4.2f;

    public float fireRate;
    float nextFire = 0f;

    bool shield;
    public GameObject Shield;

    public static bool creditos;
    UI ui;
    
    public AudioSource audioSource;
    public AudioClip soundLaser;
    public AudioClip soundHit;
    public AudioClip soundPowerUp;
    public AudioClip soundExplosion;

    public GameObject dieAnimation;

    public static bool isPause;

    public GameObject loadSceneObject;
    public LoadScene loadScene;


	// Use this for initialization
	void Start () {
        loadScene = loadSceneObject.GetComponent<LoadScene>();
        transform.position = new Vector3(0, -4.2f, 0);
        speed = 6;
        life = 6;
        shield = false;
        fireRate = 0.3f;
        Shield.SetActive(false);
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        audioSource = GetComponent <AudioSource>();
        ui.gamePlay();
        isPause = false;
        ui.blackScreenOff();
        ui.victoryOff();
        creditos = false;
    }
	
	// Update is called once per frame
	void Update () {
        playerMovement();
        fireLaser();
        playerLose();
        pause();
        playerVictory();

    }


    void playerMovement()
    {
        vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(horizontal, vertical, 0);

        if(transform.position.y < maxBottom)
        {
            transform.position = new Vector3(transform.position.x, maxBottom, transform.position.z);
        }
        if(transform.position.y > maxTop)
        {
            transform.position = new Vector3 (transform.position.x, maxTop, transform.position.z);
        }
        if(transform.position.x < maxLeft)
        {
            transform.position = new Vector3(maxLeft, transform.position.y, transform.position.z);
        }
        if(transform.position.x > maxRigth)
        {
            transform.position = new Vector3(maxRigth, transform.position.y, transform.position.z);
        }
    }

    void fireLaser()
    {
        if(isPause == false)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(laser, transform.position + new Vector3(0.3f, 1f, 0), Quaternion.identity);
                    audioSource.PlayOneShot(soundLaser);
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if(shield != true)
            {
                life -= 1;
                audioSource.PlayOneShot(soundHit);
            }
        }
        if (other.tag == "LaserEnemy")
        {
            if (shield != true)
            {
                life -= 1;
                audioSource.PlayOneShot(soundHit);
            }
        }
        if (other.tag == "Hp" || other.tag == "Speed" || other.tag == "FastShoot" || other.tag == "Armor")
        {
            audioSource.PlayOneShot(soundPowerUp , 1.5f);
        }
        ui.updateLives(life);
    }

    public void powerUpHp()
    {
        if (life < 6){
            life += 1;
        }
        ui.updateLives(life);
        

    }

    public void powerUpShield()
    {
        shield = true;
        Shield.SetActive(true);
        StartCoroutine(sleepShield());
    }

    public void powerUpFastShoot()
    {
        fireRate = 0.17f;
        StartCoroutine(sleepFastShoot());
    }

    public void powerUpSpeed()
    {
        speed = 10;
        StartCoroutine(sleepSpeed());
    }

    IEnumerator sleepSpeed()
    {
        yield return new WaitForSeconds(7);
        speed = 6;
    }

    IEnumerator sleepFastShoot()
    {
        yield return new WaitForSeconds(10);
        fireRate = 0.3f;
    }

    IEnumerator sleepShield()
    {
        yield return new WaitForSeconds(10);
        shield = false;
        Shield.SetActive(false);
    }

    void pause()
    {
        if(isPause == false)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                ui.gamePause();
            }
        }
        
    }
    void playerLose()
    {
        if (isPause == false)
        {
            if (life == 0)
            {
                AudioSource.PlayClipAtPoint(soundExplosion, Camera.main.transform.position, 0.5f);
                Instantiate(dieAnimation, transform.position, Quaternion.identity);
                ui.lose();
                Destroy(this.gameObject);
                



            }
        }
    }

    void playerVictory()
    {
        if(isPause == false)
        {
            if(Spawn.numberDeaths == 20)
            {
                Spawn.spawnEnemies = false;
                Spawn.spawnPowerups = false;
                StartCoroutine(sleepVictory());
                StartCoroutine(sleepBlackScreen());
                creditos = true;
            }
        }
        
    }

    IEnumerator sleepVictory()
    {
        yield return new WaitForSeconds(3);
        ui.victoryOn();
        yield return new WaitForSeconds(3);
        ui.blackScreenOn();
        isPause = true;
    }

    IEnumerator sleepBlackScreen()
    {
        yield return new WaitForSeconds(15);
        loadScene.loadScene("CREDITOS");
    }

}

