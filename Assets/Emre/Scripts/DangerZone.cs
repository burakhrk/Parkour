using Etra.StarterAssets.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DangerZone : MonoBehaviour
{
    [SerializeField]StarterAssetsInputs starterAssetsInputs;

    public GameObject LosePanel;

    LevelController levelController;

    private void Start()
    {
        starterAssetsInputs = FindObjectOfType<StarterAssetsInputs>().GetComponent<StarterAssetsInputs>();
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
        Cursor.lockState = CursorLockMode.None;
    }
}
