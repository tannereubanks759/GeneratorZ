using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DraggableUI : MonoBehaviour
{
    public SpriteRenderer renderer;

    Vector2 position;
    Vector2 startPosition;
    public GameObject turretSprite;
    public GameObject turret;

    public Collider2D[] surrounding;

    public bool isDragging;

    public bool affordable;
    public int coins;

    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        renderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private Vector3 offset;
    
    public LayerMask mask;
    // Update is called once per frame
    void Update()
    {
        coins = gm.coinsGet();

        if (Affordable())
        {
            renderer.color = Color.green;
        }
        else
        {
            renderer.color = Color.red;
        }


        if (isDragging == true)
        {
            surrounding = Physics2D.OverlapCircleAll(this.transform.position, .5f, mask);
            if (surrounding.Length > 0 || !Affordable())
            {
                renderer.color = Color.red;
            }
            else
            {
                renderer.color = Color.green;
            }

            position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            this.transform.position = position;
        }
        
    }
    private void OnMouseDown()
    {
        isDragging = true;
        offset = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseUp()
    {
        if(renderer.color == Color.green)
        {
            Instantiate(turret, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            gm.coinsSet(50);
        }
        isDragging = false;
        this.transform.position = startPosition;
    }
    bool Affordable()
    {
        if(this.gameObject.tag == "turret" && coins >= 50)
        {
            return true;
        }
        else if(this.gameObject.tag == "cannon" && coins >= 100)
        {
            return true;
        }
        else if(this.gameObject.tag == "barrier" && coins >= 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
