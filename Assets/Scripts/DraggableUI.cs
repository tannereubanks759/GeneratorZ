using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DraggableUI : MonoBehaviour
{
    Vector2 position;
    Vector2 startPosition;
    public GameObject turretSprite;

    public Collider2D[] surrounding;

    public bool isDragging;

    public SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        
    }

    private Vector3 offset;
    
    public LayerMask mask;
    // Update is called once per frame
    void Update()
    {
        if (isDragging == true)
        {
            surrounding = Physics2D.OverlapCircleAll(this.transform.position, .5f, mask);
            if (surrounding.Length > 0)
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
        offset = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
        this.transform.position = startPosition;
    }

}
