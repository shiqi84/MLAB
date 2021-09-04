using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] nodes;
    playerMove current;
    void Start()
    {   nodes = GameObject.FindGameObjectsWithTag("node");
        Debug.Log(nodes.Length);
    }

    // Update is called once per frame
    void Update()
    {
        clickMouse();
    }
    private void clickMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            playerMove t = null;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider.tag == "node")
            {
                t = hit.collider.GetComponent<playerMove>();
                t.selected = true;
            }

        }

    }

}
