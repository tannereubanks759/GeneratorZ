using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();

    public float nextFire;
    public float fireRate = 1;

    public GameObject enemyPref;

    public GameObject[] spawnPositions = new GameObject[3];

    public int coins;
    public TMP_Text coinstxt;

    public TMP_Text healthtxt;

    public float generatorHealth = 100f;

    public GameObject gen;

    public GameObject DeathScreen;

    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        nextFire = Time.time;
        coinstxt.text = "Coins: " + coins;
        healthtxt.text = "Generator Health: " + generatorHealth;
        DeathScreen.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
        if(generatorHealth <= 0)
        {
            die();
        }
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            EnemyList.Add(Instantiate(enemyPref, spawnPositions[0].transform.position, Quaternion.identity));
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
        generatorHealth -= value;
        healthtxt.text = "Generator Health: " + generatorHealth;
    }
    public void die()
    {
        isDead = true;
        DeathScreen.SetActive(true);
        Time.timeScale = 0f;
        Destroy(gen);
    }
}
