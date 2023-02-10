using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksToDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)  //Caso o Player fique abaixo do nível da água ele muda a condição de vitória
    {
        if (col.gameObject.tag == "BossHand")
        {
            Destroy(this.gameObject);
            Debug.Log("Tocou hand");
        }
    }
}
