using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();

    public float nextFire;
    public float fireRate = 1;

    public GameObject enemyPref;

    public GameObject[] spawnPositions = new GameObject[3]; 
    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
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
}
