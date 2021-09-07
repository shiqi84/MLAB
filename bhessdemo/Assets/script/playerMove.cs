using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : baseMove
{

    private gameManager gm;
 
    
    // Start is called before the first frame update
    void Start()
    {
        init();
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
    }

    void Update()
    {
        if (selected&&moveable)
        {
            moveNode();
        }
     
    }
    private void moveNode()
    {
        if (!moving)
        {
            findSelectable();
            clickMouse();
        }
        else
        {
            move();


    }
}

    private void clickMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            tile t = null;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider.tag == "tile")
            {
                t = hit.collider.GetComponent<tile>();
                
                if (t.selectable&moveable)
                {
                  
                    moveTo(t);
                }
            }
            else
            {
                gm.reset();
            }

        }

    }
   
    

       }


