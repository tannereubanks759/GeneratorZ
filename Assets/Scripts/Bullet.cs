using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    
    public Rigidbody2D rb;
    public float PushForce;
    private GameObject GunEnd;

    public GameObject enemy;
    public GameObject turret;
    public GameObject[] turrets;
    // Start is called before the first frame update
    void Start()
    {
        turrets = GameObject.FindGameObjectsWithTag("turret");
        turret = GetClosestTurret(turrets);
        enemy = turret.GetComponent<TurretScript>().EnemyGet();
        
        Vector3 direction = enemy.transform.position - transform.position;
        
        rb.velocity = new Vector2(direction.x, direction.y).normalized * PushForce;
    }
    
    GameObject GetClosestTurret(GameObject[] turrets)
    {
        GameObject tMin = null;
        float minDist = 3;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in turrets)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
}
