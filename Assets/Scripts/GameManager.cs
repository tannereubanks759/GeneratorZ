using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();

    public float nextFire;
    public float fireRate = 1;

    public GameObject enemyPref;
    public GameObject tank;

    public GameObject[] spawnPositions = new GameObject[3];

    public int coins;
    public TMP_Text coinstxt;

    public TMP_Text healthtxt;

    public float generatorHealth = 100f;

    public GameObject gen;
    public SpriteRenderer rend;
    public float rateTime;
    private float nextTime;

    public GameObject DeathScreen;

    public bool isDead;

    public AudioSource click;
    public AudioSource explode;
    //round variables
    public bool roundStarted = false;
    public GameObject symbol;
    private int enemiesSpawned = 0;
    private int round = 1;
    public GameObject startRoundButton;
    public float random;
    public GameObject currentEnemy;

    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        nextFire = Time.time;
        coinstxt.text = "Coins: " + coins;
        healthtxt.text = "Generator Health: " + generatorHealth;
        DeathScreen.SetActive(false);
        rend = gen.GetComponent<SpriteRenderer>();
        nextTime = Time.time;
        rend.color = Color.white;
        rateTime = 1f;

        symbol = GameObject.Find("Symbol");
        symbol.transform.position = new Vector3(-0.6499f, -4.510f, 0.520f);
        explode = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if(generatorHealth <= 0)
        {
            die();
        }

        if (roundStarted == true)
        {
            if(round == 1)
            {
                roundOne();
            }
            else if (round == 2)
            {
                roundTwo();
            }
            else
            {
                roundThree();
            }
        }
        else
        {
            enemiesSpawned = 0;
        }
        

        if(generatorHealth < 100)
        {
            genBlink();
        }

        
    }
    public List<GameObject> EnemyListGet()
    {
        return EnemyList;
    }
    public int coinsGet()
    {
        return coins;
    }
    public void coinsSet(int value)
    {
        coins -= value;
        coinstxt.text = "Coins: " + coins;
    }
    public void hurtGen(float value)
    {
        if(generatorHealth == 100)
        {
            rateTime -= .0f;
        }
        else
        {
            rateTime -= .25f;
        }
        generatorHealth -= value;
        healthtxt.text = "Generator Health: " + generatorHealth;
        
    }
    public void die()
    {
        explode.Play();
        isDead = true;
        DeathScreen.SetActive(true);
        Time.timeScale = 0f;
        Destroy(gen);
    }
    public void genBlink()
    {
        if(Time.time >= nextTime)
        {
            if(rend.color == Color.white)
            {
                rend.color = Color.red;
            }
            else
            {
                rend.color = Color.white;
            }
            nextTime = Time.time + rateTime;
        }
    }
    public void StartRound()
    {
        click.Play();
        roundStarted = true;
        startRoundButton.SetActive(false);
    }

    public void roundOne()
    {
        symbol.SetActive(false);
        if (Time.time > nextFire)
        {
            random = Random.Range(0f, 10f);
            if(random <= 8)
            {
                currentEnemy = enemyPref;
            }
            else if(random > 8)
            {
                currentEnemy = tank;
            }
            else
            {
                currentEnemy = enemyPref;
            }
            nextFire = Time.time + fireRate;
            EnemyList.Add(Instantiate(currentEnemy, spawnPositions[0].transform.position, Quaternion.identity));
            enemiesSpawned += 1;
        }
        
        if (enemiesSpawned >= 20)
        {
            
            symbol.SetActive(true);
            symbol.transform.position = new Vector3(-6.57000017f, 0.0900000036f, 0.520492733f);
            round = 2;
            roundStarted = false;
            startRoundButton.SetActive(true);
        }
    }
    public void roundTwo()
    {
        
        symbol.SetActive(false);

        if (Time.time > nextFire)
        {
            random = Random.Range(0f, 10f);
            if (random <= 8)
            {
                currentEnemy = enemyPref;
            }
            else if (random > 8)
            {
                currentEnemy = tank;
            }
            else
            {
                currentEnemy = enemyPref;
            }
            nextFire = Time.time + fireRate;
            EnemyList.Add(Instantiate(currentEnemy, spawnPositions[0].transform.position, Quaternion.identity));
            EnemyList.Add(Instantiate(currentEnemy, spawnPositions[1].transform.position, Quaternion.identity));
            enemiesSpawned += 1;
        }
        if (enemiesSpawned >= 30)
        {
            symbol.SetActive(true);
            symbol.transform.position = new Vector3(-0.860000014f, 4.21000004f, 0.520492733f);
            round = 3;
            roundStarted = false;
            startRoundButton.SetActive(true);
        }
    }
    public void roundThree()
    {
        
        symbol.SetActive(false);
        if (Time.time > nextFire)
        {
            random = Random.Range(0f, 10f);
            if (random <= 8)
            {
                currentEnemy = enemyPref;
            }
            else if (random > 8)
            {
                currentEnemy = tank;
            }
            else
            {
                currentEnemy = enemyPref;
            }
            nextFire = Time.time + fireRate;
            EnemyList.Add(Instantiate(currentEnemy, spawnPositions[0].transform.position, Quaternion.identity));
            EnemyList.Add(Instantiate(currentEnemy, spawnPositions[1].transform.position, Quaternion.identity));
            EnemyList.Add(Instantiate(currentEnemy, spawnPositions[2].transform.position, Quaternion.identity));
            enemiesSpawned += 1;
        }
        if (enemiesSpawned >= 40)
        {
            StartCoroutine(End());
            roundStarted = false;
            
        }
    }
    public IEnumerator End()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("End");
        
    }
}
