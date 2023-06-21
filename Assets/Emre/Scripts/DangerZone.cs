using Etra.StarterAssets.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField]StarterAssetsInputs starterAssetsInputs;

    public GameObject LosePanel;




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
         LosePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
