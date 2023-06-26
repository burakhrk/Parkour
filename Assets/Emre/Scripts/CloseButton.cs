using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] GameObject InfoPanel;
    GameObject cursor;



    private void Start()
    {
        cursor =FindObjectOfType<Cursorr>().gameObject;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        cursor.SetActive(false);
    }

    public void ClosePanel()
    {
        InfoPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        cursor.SetActive(true); 
    }
}
