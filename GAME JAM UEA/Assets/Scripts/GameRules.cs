using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 10f;
    private bool fallChar = true;
    public GameObject[] blocks;
    public float spawnRate = 0.5f;
    
    public GameObject playerCloud;
    public GameObject playerToFall;
    public Rigidbody2D rbPlayer;
    public Text countdownText;
    public static bool canFallBlocks = false;
    private Vector2 m_NewForce;
    
    // Start is called before the first frame update
    void Start()
    {
        m_NewForce = new Vector2(0, 4f);
        currentTime = startingTime;
        playerCloud.SetActive(true);
        playerToFall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
       
        if (currentTime <= 0)
        {
            currentTime = 0f;
            canFallBlocks = false;
            PlayerMovement.canMove = false;
            FallCharacter();
        }
        if (canFallBlocks == true)
        {
            canFallBlocks = false;
            StartCoroutine(BlocksSpawn());
            
        }
 
    }

    void FallCharacter()
    {
        if (fallChar==true)
        {
            playerCloud.SetActive(false);
            playerToFall.SetActive(true);
            rbPlayer.AddForce(m_NewForce, ForceMode2D.Impulse);
            fallChar = false;
        }
    }

    IEnumerator BlocksSpawn()
    {
        GameObject gameObject = Instantiate(blocks[Random.Range(0, blocks.Length)], playerCloud.transform.position, playerCloud.transform.rotation);
        yield return new WaitForSeconds(spawnRate);
        Debug.Log("pode voltar");
        canFallBlocks = true;

    }
}
