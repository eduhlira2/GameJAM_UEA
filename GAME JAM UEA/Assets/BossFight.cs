using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public Animator bossAnim;
    public GameObject winPanel;
    public int bossLife = 3;
    // Start is called before the first frame update
    void Start()
    {
        bossAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossLife <= 0)
        {
            bossAnim.SetBool("Dead", true);
            winPanel.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Ganhou o Jogo");
            
        }
        
    }
    void OnTriggerEnter2D(Collider2D col)  //Caso o Player fique abaixo do nível da água ele muda a condição de vitória
    {
        if (col.gameObject.tag == "TNT")
        {
            bossLife--;
            Debug.Log("Boss Levou Dano!");
        }
    }
  
}
