using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseMove : MonoBehaviour
{
    public int mobility = 5;
    public float jumpHeight = 2.0f;
    public float moveSpeed = 2;
    public bool moving = false;

    public tile currentTile;

    GameObject[] tiles;
    List<tile> selectable = new List<tile>();
    Stack<tile> path = new Stack<tile>();


    protected void init()
    {
        tiles = GameObject.FindGameObjectsWithTag("tile");

    }

    public void getCurrentTile()
    {
        currentTile = getTargetTile(gameObject);
        currentTile.current = true;
    }

    public tile getTargetTile(GameObject target)
    {
        tile tile = null;
        Collider2D myCollider = gameObject.GetComponent<Collider2D>();
        int numColliders = 10;
        Collider2D[] colliders = new Collider2D[numColliders];
        ContactFilter2D contactFilter = new ContactFilter2D();
        int colliderCount = myCollider.OverlapCollider(contactFilter, colliders);
        tile=colliders[0].GetComponent<tile>();

        return tile;
    }
    public void computeAdjacentList()
    {
      
        foreach (GameObject tile in tiles)
        {
            tile t = tile.GetComponent<tile>();
            t.getNeighbhour();

        }
    }


    public void findSelectable()
    {
        computeAdjacentList();
        getCurrentTile();

        Queue<tile> process = new Queue<tile>();

        process.Enqueue(currentTile);
        currentTile.visited = true;


        while (process.Count > 0)
        {
            
            tile t = process.Dequeue();

            selectable.Add(t);
            t.selectable = true;

            if (t.distance < mobility)
            {
               
                foreach (tile tile in t.adjacencyList)
                {
                    if (!tile.visited)
                    {
                        tile.parent = t;
                        tile.visited = true;
                        tile.distance = 1 + t.distance;
                        process.Enqueue(tile);
                    }
                }
            }

        }
    }

    public void moveTo(tile t)
    {
        path.Clear();
        t.target = true;
        moving = true;

        tile next = t;
        while (next != null)
        {
            path.Push(next);
            next = next.parent;

        }



    }

    public void move()
    {
        if (path.Count > 0)
        {
            tile t = path.Peek();
            Vector2 target = t.transform.position;

            //target.y += halfHeight + t.GetComponent<Collider>().bounds.extents.y;
            if (Vector2.Distance(transform.position, target) >= 0.05f)
            {
              
                transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime*0.9f);
        
            }
            else
            {
                transform.position = target;
                path.Pop();
            }
        }
        else
        {
            removeSelectedTile();
            getCurrentTile();

            moving = false;
        }

    }
 

    protected void removeSelectedTile()
    {
        if (currentTile != null)
        {
            currentTile.current = false;
            currentTile = null;
        }
        foreach (tile t in selectable)
        {
            t.Reset();
        }
        selectable.Clear();
    }
}
