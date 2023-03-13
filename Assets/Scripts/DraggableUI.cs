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

    public int price;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        renderer = this.gameObject.GetComponent<SpriteRenderer>();
        UIScript = GameObject.FindGameObjectWithTag("ui").GetComponent<Ui>();
    }

    private Vector3 offset;
    
    public LayerMask mask;

    public Ui UIScript;
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
            float radius;
            if(this.gameObject.tag == "Barrier")
            {
                radius = 1f;
            }
            else
            {
                radius = .5f;
            }
            surrounding = Physics2D.OverlapCircleAll(this.transform.position, radius, mask);
            if (surrounding.Length > 0 || !Affordable())
            {
                renderer.color = Color.red;
            }
            else
            {
                renderer.color = Color.green;
            }

            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = position;
        }
        
    }
    private void OnMouseDown()
    {
        if (UIScript.isPaused != true && gm.isDead != true)
        {
            isDragging = true;
        }
        
    }
    private void OnMouseUp()
    {
        if(renderer.color == Color.green && UIScript.isPaused != true && gm.isDead != true)
        {
            Instantiate(turret, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            gm.coinsSet(price);
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
        else if(this.gameObject.tag == "Barrier" && coins >= 150)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
