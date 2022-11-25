using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject panelStart;
    
    public GameObject player;
    public float speed;

    private int movementOrientation;

    public static bool canMove = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        movementOrientation = 1;
        panelStart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            if (player.transform.position.x >= 2.38f)
            {
                movementOrientation = -1;
            }

            if (player.transform.position.x <= -2.31f)
            {
                movementOrientation = 1; 
            }
            player.transform.position += new Vector3(movementOrientation,0,0) * Time.deltaTime * speed;     
        }
    }

    public void TouchToStart()
    {
        Time.timeScale = 1;
        panelStart.SetActive(false);
        canMove = true;
        RulesGameController.canFallBlocks = true;
    }
    
    public void GotoLeft()
    {
        movementOrientation = -1;
    }
    
    public void GotoRight()
    {
        movementOrientation = 1;
    }
}
