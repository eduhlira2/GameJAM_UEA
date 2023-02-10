using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoss : MonoBehaviour
{
    private bool isFighting = true;
    
    
    public GameObject lostPanel;
    
    public GameObject panelStart;
    public GameObject ocean;
    public float waterLimit;
    public GameObject player;
    public float speed;

    private int movementOrientation;
    public static bool canMove = false;
    
    public GameObject[] blocks;
    public float spawnRate = 0.5f;
    public static bool canFallBlocks = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        panelStart.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (canMove == true)
        {
            UpWater();
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
        if (canFallBlocks == true) // ativa e desativa a possibilidade de instanciar um novo bloco. dando tempo para gerar aos poucos.
        {
            canFallBlocks = false;
            StartCoroutine(BlocksSpawn());
            
        }
    }
    
    public void TouchToStart()
    {
        Time.timeScale = 1;
        panelStart.SetActive(false);
        canMove = true;
        canFallBlocks = true;
        GotoRight();
    }
    public void GotoLeft()
    {
        movementOrientation = -1;
    }
    
    public void GotoRight()
    {
        movementOrientation = 1;
    }
    
    IEnumerator BlocksSpawn() //função que gera os blocos de forma randomica.
    {
        GameObject gameObject = Instantiate(blocks[Random.Range(0, blocks.Length)], player.transform.position, player.transform.rotation);
        yield return new WaitForSeconds(spawnRate);
        canFallBlocks = true;

    }
    
    void UpWater()
    {
        if (isFighting)
        {if (ocean.transform.position.y <= waterLimit)
            {
                //Debug.Log("Ta subindo");
                ocean.transform.position += new Vector3(0,1,0) * Time.deltaTime * 0.5f;
            }
            else
            {
                Debug.Log("GameOver");
                Time.timeScale = 0;
                lostPanel.SetActive(true);


            }
            
        }
        else
        {
            
            Debug.Log("Venceu o jogo");
            
        }
        
    }
}

