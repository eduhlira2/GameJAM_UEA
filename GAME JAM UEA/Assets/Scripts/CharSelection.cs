using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharSelection : MonoBehaviour
{
    public int valorTeste;
    
    public Button[] charactersToSelection;
    
    // Start is called before the first frame update
    void Start()
    {
        //Definir PlayerPrefs
        PlayerPrefs.SetInt("chars", valorTeste);
        
    }

    // Update is called once per frame
    void Update()
    {
        int value = PlayerPrefs.GetInt("chars");
        for (int i = 0; i < value; i++)
        {
            charactersToSelection[i].image.color = Color.white;
            charactersToSelection[i].enabled = true;
        }
    }

    public void CharSelected(int charToPlay)
    {
        PlayerPrefs.SetInt("charToPlay", charToPlay);
    }
}
