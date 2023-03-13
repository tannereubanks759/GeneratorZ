using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float health = 100;
    public GameObject generator;
    public GameObject GameManagerObject;
    public GameManager gm;
    public float speed = .2f;
    
    // Start is called before the first frame update
    void Start()
    {
        generator = GameObject.FindGameObjectWithTag("Generator");
        GameManagerObject = GameObject.FindGameObjectWithTag("gm");
        gm = GameManagerObject.GetComponent<GameManager>();


        Vector3 rotation = generator.transform.position - this.transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90;
        this.transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.up * Time.deltaTime * speed);
        
        
    }
    public void Damage(float amount)
    {
        health -= amount;
        if(health <= 0 && gm.EnemyList.IndexOf(this.gameObject) > -1)
        {
            gm.EnemyList.RemoveAt(gm.EnemyList.IndexOf(this.gameObject));
            gm.coinsSet(-7);
            Destroy(this.gameObject);
        }
    }
    public void Damage(float amount, bool genDied)
    {
        
        gm.hurtGen(20);
        health -= amount;
        if (health <= 0)
        {
            gm.EnemyList.RemoveAt(gm.EnemyList.IndexOf(this.gameObject));
            if (genDied)
            {
                gm.coinsSet(10);
            }
            else
            {
                gm.coinsSet(-7);
            }
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            Damage(15);
        }
        if(collision.gameObject.tag == "CannonBall")
        {
            Damage(300);
        }
        if(collision.gameObject.tag == "Generator")
        {
            Damage(999, true);
        }
        if (collision.gameObject.tag == "Barrier")
        {
            speed = 0f;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            speed = .2f;
        }
    }
}
