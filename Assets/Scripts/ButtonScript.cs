using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ButtonScript : MonoBehaviour
{
    private bool bA;
    public bool buttonActive;


    private void OnTriggerStay2D(Collider2D collision)
     {
        
        if (collision.gameObject.tag == "Player")
         {
            Debug.Log("Player here");
            bA = true;
         }
     }
    private void OnTriggerExit2D(Collider2D collision)
    {
        bA = false;
    }

    private void Update()
    {
        if (bA)
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                 Debug.Log("E pressed");
                
                Debug.Log("Button Active 1");
                buttonActive = true;
            }
            
        }
    }
}
