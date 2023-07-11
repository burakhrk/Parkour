using Etra.StarterAssets.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DangerZone : MonoBehaviour
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
            
            Fail();
        }
    }
    void Fail()
    {
        Time.timeScale = 0f;
        levelController.LosePanelActivate();
        
    }
}
