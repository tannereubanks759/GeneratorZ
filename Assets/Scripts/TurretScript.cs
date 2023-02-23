using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public GameObject barrel;
    public GameObject GunEnd;
    public GameObject pivot;
    public GameObject bulletPref;
    
    

    public Vector3 targetPos;

    public List<GameObject> Enemies = new List<GameObject>();


    public float nextFire;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
        fireRate = .2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemies.Count > 0)
        {
            targetPos = GetClosestEnemy(Enemies).transform.position;
        }
        Vector3 rotation = targetPos - this.transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90;
        pivot.transform.rotation = Quaternion.Euler(0, 0, rotZ);


        if (Enemies.Count > 0 && Time.time > nextFire)
        {
            
            nextFire = Time.time + fireRate;
            Debug.Log("shoot");
        }
    }
    private void shoot()
    {
        GameObject bullet = Instantiate(bulletPref, GunEnd.transform.position, Quaternion.identity);
        Debug.Log("shoot");
        
    }
    public GameObject GetClosestEnemy(List<GameObject> enemies)
    {
        GameObject tMin = null;
        float minDist = 3;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
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
    public GameObject EnemyGet()
    {
        return GetClosestEnemy(Enemies);
    }
}
