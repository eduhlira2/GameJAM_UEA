using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StageButtonSelection : MonoBehaviour
{
    public int valorTeste;
    
    public Button[] stageButton;
    
    // Start is called before the first frame update
    void Start()
    {
        //Usar essa linha para teste de parâmetro de fases conquistadas pelo jogador PlayerPrefs
       // PlayerPrefs.SetInt("stagesUnlocked", valorTeste);
        
    }

    // Update is called once per frame
    void Update()
    {
        int value = PlayerPrefs.GetInt("stagesUnlocked");
        for (int i = 0; i < value; i++)
        {
            print("entrou aqui ohh");
            stageButton[i].image.color = Color.white;
            stageButton[i].enabled = true;
        }
    }
}
