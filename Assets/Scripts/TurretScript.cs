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

    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
        fireRate = .2f;
    }

    // Update is called once per frame
    void Update()
    {
        Enemies = gm.EnemyListGet();

        if (Enemies.Count > 0 && InRange(Enemies[0]))
        {
            targetPos = Enemies[0].transform.position;
        }
        Vector3 rotation = targetPos - this.transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90;
        pivot.transform.rotation = Quaternion.Euler(0, 0, rotZ);


        if (Enemies.Count > 0 && Time.time > nextFire && InRange(Enemies[0]))
        {
            shoot();
            nextFire = Time.time + fireRate;
            Debug.Log("shoot");
        }
    }
    private void shoot()
    {
        Instantiate(bulletPref, GunEnd.transform.position, pivot.transform.rotation);
        Debug.Log("shoot");
        
    }
    public bool InRange(GameObject enemy)
    {
        float dist = Vector3.Distance(enemy.transform.position, this.transform.position);
        if (dist < 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
}
