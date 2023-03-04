using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        transform.position += transform.TransformDirection(Vector3.up * Time.deltaTime * 3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "tree")
        {
            Destroy(this.gameObject);
        }
    }

}
