using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    public GameObject pivot;
    

    public Vector3 targetPos;

    public List<GameObject> Enemies = new List<GameObject>();


    public float nextFire;
    public float fireRate;

    public GameManager gm;

    public GameObject generator;

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        nextFire = Time.time;
        fireRate = 2f;
        generator = GameObject.FindGameObjectWithTag("Generator");
    }

    // Update is called once per frame
    void Update()
    {

        if(health <= 0)
        {
            die();
        }

        Enemies = gm.EnemyListGet();
        Vector3 rotation = generator.transform.position - this.transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90;
        pivot.transform.rotation = Quaternion.Euler(0, 0, rotZ);


        if (Enemies.Count > 0 && Time.time > nextFire && InRange(Enemies[0]))
        {
            Damage(25);
            nextFire = Time.time + fireRate;
            Debug.Log("shoot");
        }
    }
    
    public bool InRange(GameObject enemy)
    {
        float dist = Vector3.Distance(enemy.transform.position, this.transform.position);
        if (dist < 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Damage(int damage)
    {
        health -= damage;
    }
    void die()
    {
        Destroy(this.gameObject);
    }

}
