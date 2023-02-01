using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RulesGameController : MonoBehaviour
{
    public GameObject character;

    public int actualLevel;
    private bool needKey;
    public static bool key;
    public GameObject keyObj;
    
    public float spawnRate = 0.5f;
    private float currentTime = 0f;
    private float startingTime = 10f;
    public float waterLimit;
    private bool fallChar = true;
    private SpriteRenderer playerCloudSprite;
    private SpriteRenderer  playerFallSprite;
    
    private bool canWin;
    
    public GameObject[] blocks;
    public GameObject ocean;
    public GameObject winPanel;
    public GameObject lostPanel;
    public GameObject lineLimit;
    public GameObject playerCloud;
    public GameObject playerToFall;
    public Rigidbody2D rbPlayer;
    
    public static int winCondition = 0;
    public static bool waterVerify = false;
    public static bool canFallBlocks = false;
    
    public Text countdownText;
    private Vector2 m_NewForce;
    
    // Start is called before the first frame update
    void Start()
    {
        key = false;
        canWin = false;
        Debug.Log(PlayerPrefs.GetInt("stars"));
       
        //waterLimit = Random.Range(-0.57f, 0.49f);
        waterVerify = false;
        m_NewForce = new Vector2(0, 4f);
        currentTime = startingTime;
        playerCloud.SetActive(true);
        playerToFall.SetActive(false);
        winCondition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetKeyToWin();
        
        lineLimit.transform.position = new Vector3(0, waterLimit, 0);
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        
        if (ocean.transform.position.y >= waterLimit)  //Faz a verificação se venceu ou não
        {
            if (winCondition == -1)
            {
                winPanel.SetActive(false);
                lostPanel.SetActive(true);
                Time.timeScale = 0;
            }
            if (winCondition == 0  && canWin)
            {
                lostPanel.SetActive(false);
                winPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        
        if (currentTime <= 0) //Quando o tempo acabar faz tudo ficar parado e chama a função do personagem caindo.
        {
            currentTime = 0f;
            canFallBlocks = false;
            PlayerMovement.canMove = false;
            FallCharacter();
        }
        if (canFallBlocks == true) // ativa e desativa a possibilidade de instanciar um novo bloco. dando tempo para gerar aos poucos.
        {
            canFallBlocks = false;
            StartCoroutine(BlocksSpawn());
            
        }
        UpWater();
 
    }

    void GetKeyToWin()
    {
        if (actualLevel == 3 || actualLevel == 4 || actualLevel == 5)
        {
            needKey = true;
        }
    }
    
    void FallCharacter()
    {
        if (fallChar==true) // função que ativa o sprite do personagem caindo.
        {
            playerCloud.SetActive(false);
            playerToFall.SetActive(true);
            rbPlayer.AddForce(m_NewForce, ForceMode2D.Impulse);
            waterVerify = true;
            fallChar = false;
        }
    }

    IEnumerator BlocksSpawn() //função que gera os blocos de forma randomica.
    {
        GameObject gameObject = Instantiate(blocks[Random.Range(0, blocks.Length)], playerCloud.transform.position, playerCloud.transform.rotation);
        yield return new WaitForSeconds(spawnRate);
        canFallBlocks = true;

    }

    void UpWater()
    {
        if (waterVerify == true) // faz a água subir até o limite gerado de forma randomica.
        {
            if (ocean.transform.position.y <= waterLimit)
            {
                //Debug.Log("Ta subindo");
                ocean.transform.position += new Vector3(0,1,0) * Time.deltaTime * 2f;
            }
            else
            {
                //Debug.Log("Parou de subir");
                waterVerify = false;
                StartCoroutine(TimerToVerify());

            }
        }
    }

    IEnumerator TimerToVerify()
    {
        if (!needKey)
        {
            yield return new WaitForSeconds(2);
            canWin = true;
        }
        if (needKey)
        {
            if (key)
            {
                yield return new WaitForSeconds(2);
                canWin = true;
            }
            else
            {
                winCondition = -1;
            }
        }

    }

    public void GoToScene (string scene) //função que reinicia a cena.
    {

        if (winCondition == 0)
        {
            PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars") +1);
            Debug.Log("aumentou estrelas");
        }

        if (winCondition == -1)
        {
            PlayerPrefs.SetInt("stars", 0 );
        }
        SceneManager.LoadScene(scene);
    }
    

}

