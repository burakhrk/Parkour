using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject LWLSelectPanel;

    [SerializeField] AdManager _adManager;

    private void Awake()
    {
        _adManager.Init();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;

       // ShowAd();
    }

    public void PlayButton()
    {
        if (PlayerPrefs.HasKey("LevelUnlocked"))
        {
            var a  = PlayerPrefs.GetInt("LevelUnlocked", 1);
            PlayerPrefs.SetInt("Level",a);

        }
        else
        {
             
            PlayerPrefs.SetInt("Level", 1);
        }
           

        ShowAd();
        SceneManager.LoadScene(1);
        //Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowAd()
    {
        _adManager.InterstatialAdManager.ShowAd();
    }



    public void ActivateLWLSelecetPanel()
    {
        LWLSelectPanel.SetActive(true);
    }

    public void CloseLWLSelecetPanel()
    {
        LWLSelectPanel.SetActive(false);
    }
}
