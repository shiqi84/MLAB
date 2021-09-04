using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    // Start is called before the first frame update
    public bool visited=false;
    public bool selectable = false;
    public bool walkable = true;
    public bool target = false;
    public bool current = false;

    public tile parent = null;
    public int distance = 0;
    public List<tile> adjacencyList = new List<tile>();
    void Start()
    {
}

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            GetComponent<Renderer>().material.color = Color.magenta;
        }
        else if (target)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (selectable)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
      
    }

    public void Reset()
    {
        adjacencyList.Clear();

        current = false;
        target = false;
        selectable = false;

        visited = false;
        parent = null;
        distance = 0;

    }

    public void getNeighbhour()
    {
        Reset();

         CheckTile(Vector2.down);
         CheckTile(Vector2.up);
          CheckTile(Vector2.left);
         CheckTile(Vector2.right);


    }
    public void CheckTile(Vector2 direction)
    {
        Vector2 edge=new Vector2(transform.position.x+direction.x, transform.position.y + direction.y ) ;
    
        Ray2D ray = new Ray2D(edge, direction);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, direction);
       
        if (hit.collider!=null&&hit.collider.tag.Equals("tile"))
       {
            tile tile = hit.collider.GetComponent<tile>();
            adjacencyList.Add(tile);
           

        }


       
    }
    
}
