using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject moveBoard;
    // Start is called before the first frame update
    void Start()
    {
        moveBoard = GameObject.Find("Panel");
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public   void showMoveBoard(Vector2 pos)
    {
        
            moveBoard.SetActive(true);
            moveBoard.transform.position = pos;
    }


    public void closeMoveBoard()
    {
            moveBoard.SetActive(false);
       
    }
}
