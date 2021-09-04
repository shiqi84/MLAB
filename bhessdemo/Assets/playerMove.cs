﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : baseMove
{
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
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
                if (t.selectable)
                {
                    moveTo(t);
                }
            }

        }

    }
          
    

       }


