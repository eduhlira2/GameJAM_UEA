using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D col) //Coleta a Chave.
    {
        if (col.gameObject.tag == "PlayerBody")
        {
            RulesGameController.key = true;
            Debug.Log("Pegou a Chave!");
            Destroy(this.gameObject);
        }
    }
}
