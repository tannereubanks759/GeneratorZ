using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warningSymbol : MonoBehaviour
{
    public float nextFire;
    public float fireRate = .2f;

    public bool isActive = true;

    public GameObject symbol;
    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time + fireRate;

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextFire)
        {
            isActive = !isActive;
            symbol.gameObject.GetComponent<SpriteRenderer>().enabled = (isActive);
            nextFire = Time.time + fireRate;
        }
    }
}
