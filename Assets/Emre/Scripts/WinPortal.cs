using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPortal : MonoBehaviour
{
     LevelController levelController;


  

    

    private void Start()
    {
       
        
        levelController = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            levelController.ActivateWinPanel();
        }
    }
}
